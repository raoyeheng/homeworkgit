﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order(37, "张三");
            OrderDetails d7 = new OrderDetails(9, "chair", 10);           //数量，名称，单价 
            OrderDetails d1 = new OrderDetails(1, "apple", 11);
            OrderDetails d2 = new OrderDetails(2, "banana", 5);
            o1.add(d1);
            o1.add(d2);
            o1.add(d7);
            Order o2 = new Order(58, "李四");
            OrderDetails d3 = new OrderDetails(3, "chair", 10);
            OrderDetails d4 = new OrderDetails(4, "desk", 6);
            o2.add(d3);
            o2.add(d4);
            Order o3 = new Order(12, "王五");
            OrderDetails d5 = new OrderDetails(5, "egg", 3);
            OrderDetails d6 = new OrderDetails(6, "fish", 2);
            o3.add(d5);
            o3.add(d6);
            OrderService orderService = new OrderService();
            orderService.add(o1);
            orderService.add(o2);
            orderService.add(o3);

            //Console.WriteLine("排序前");
            orderService.show();

            ////排序
            orderService.sort();

            Console.WriteLine("\n排序后");
            orderService.show();

            ////查找
            Console.WriteLine("王五的订单");
            orderService.seekCltName("王");
            Console.WriteLine("58号订单");
            orderService.seekOrderID(192);
            Console.WriteLine("fish订单");
            orderService.seekProName("fish");
        }
    }
    //订单类
    class Order
    {
        public int OrderID { get; set; }
        public string CltName { get; set; }
        public int Sum { set; get; }

        public List<OrderDetails> details = new List<OrderDetails>();

        public Order(int num, string client)
        {
            OrderID = num;
            CltName = client;
            Sum = this.getSum();
        }
        //获取总价
        public int getSum()
        {
            int total = 0;
            foreach (OrderDetails detail in details)
            {
                total += detail.num * detail.price;
            }
            return total;
        }
  
        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o == null || o.OrderID == OrderID && o.CltName == CltName;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(OrderID, CltName);
        }

        //添加商品
        public void add(OrderDetails d)
        {
            bool isRepeat = false;
            foreach (OrderDetails de in details)
            {
                if (de.Equals(d))
                {
                    //Console.WriteLine(Equals(o));
                    isRepeat = true;
                    break;
                }
            }
            if (!isRepeat)
            {
                details.Add(d);
            }
            else
            {
                Console.WriteLine("重复");
            }
            Sum += d.num * d.price;
            d.OrderID = this.OrderID;
            d.CltName = this.CltName;
        }

        public override string ToString()
        {
            string s = "";
            foreach (OrderDetails d in details)
            {
                s += d.ToString();
            }
            return "订单号:" + OrderID + "\n客户名:" + CltName + "\n总价:" + Sum + "\n订单明细:" + s + "\n";
        }
    }

    //订单明细类
    class OrderDetails
    {
        public int num { get; set; }
        public string ProName { get; set; }
        public int price { get; set; }
        public int OrderID { get; set; }
        public string CltName { get; set; }
        public OrderDetails(int n, string proName, int p)
        {
            num = n;
            ProName = proName;
            price = p;
        }
        public override bool Equals(object obj)
        {
            OrderDetails d = obj as OrderDetails;
            return d == null || d.num == num && d.ProName == ProName && d.price == price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(num, ProName, price);
        }
        public override string ToString()
        {
            return "\n    商品名:" + ProName + " 数量:" + num + " 单价:" + price;
        }

    }

    //订单服务类
    class OrderService
    {
        List<Order> orders = new List<Order>();
        //添加订单
        public void add(Order o)
        {
            bool isRepeat = false;
            foreach (Order order in orders)
            {
                if (order.Equals(o))
                {
                    //Console.WriteLine(Equals(o));
                    isRepeat = true;
                    break;
                }
            }
            if (!isRepeat)
            {
                orders.Add(o);
            }
            else
            {
                Console.WriteLine("重复了");
            }
            //自动排序
            //sort();
        }

        //删除订单
        public void delete(Order o)
        {
            orders.Remove(o);
        }

        //排序
        public void sort()
        {
            orders.Sort((Order o1, Order o2) => o1.OrderID.CompareTo(o2.OrderID));
        }

        //显示全部订单
        public void show()
        {
            foreach (Order o in orders)
            {
                Console.WriteLine(o.ToString());
            }
        }

        //订单号查找
        public void seekOrderID(int a)
        {
            var query = from o in orders
                        where o.OrderID == a
                        orderby o.Sum
                        select o;
            List<Order> list = query.ToList();
            foreach (Order o in list)
            {
                Console.WriteLine(o.ToString());
            }

        }

        //客户名查询
        public void seekCltName(string a)
        {
            var query = from o in orders
                        where o.CltName == a
                        orderby o.Sum
                        select o;
            List<Order> list = query.ToList();
            foreach (Order o in list)
            {
                Console.WriteLine(o.ToString());
            }
        }

        //商品名查询
        public void seekProName(string a)
        {
            List<OrderDetails> list = new List<OrderDetails>();
            foreach (Order o in orders)
            {
                var query = from d in o.details
                            where d.ProName == a
                            select d;
                List<OrderDetails> list1 = query.ToList();
                list.InsertRange(0, list1);
                list.Sort((OrderDetails o1, OrderDetails o2) => o1.num.CompareTo(o2.num));
            }
            foreach (OrderDetails d in list)
            {
                Console.WriteLine(d.ToString() + " 订单号:" + d.OrderID + " 客户名:" + d.CltName);
            }

        }
    }


}

