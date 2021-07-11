using VMP.Dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace VMP.Dashboard.Models
{


    public class saleRevenue
    {
        public string sale { get; set; }
        public double? revenue { get; set; }
    }

    public class totalsales
    {
        public double sales { get; set; }

        public double Rev_Growth { get; set; }
    }

    public class productListed
    {
        public int product { get; set; }

        public decimal Rev_Growth { get; set; }
    }
    public class OrderbyValue
    {
        public double? order { get; set; }
        public int ordercount { get; set; }
    }

    public class OrderbyPricebucket
    {
        //public double? order { get; set; }
        public string Pricebucket { get; set; }
        public int ordercount { get; set; }
    }

    public class RevenueOverTime1
    {
        public Nullable<double> PreviousSeriesValue { get; set; }
        public DateTime Month { get; set; }
        public Nullable<double> CurrentSeriesValue { get; set; }
    }

    public class MyPieChartModelDb
    {
        public string SegmentName { get; set; }
        public double SegmentValue { get; set; }
        public string fill { get; set; }
    }
    public class CustomerPieDb
    {
        public string CustomerName { get; set; }
        public double CustomerValue { get; set; }
        public string fill { get; set; }
    }
    public class TrafficModelDb
    {
        public string State { get; set; }

        public int Sales { get; set; }  
    }
    public class DeviceTypeDb
    {
        public string Subbcategory { get; set; }
        public int CustomerCount { get; set; }
        public string fill { get; set; }
    }

    public class OrderOverTimeDb
    {
        public Nullable<int> PreviousOrder { get; set; }
        public DateTime Month { get; set; }
        public Nullable<int> CurrentOrder { get; set; }
    }

    public class TrafficSourceDb
    {
        public string Region { get; set; }
        public int CustomerCount { get; set; }
        public string fill { get; set; }
    }

    public class VisitOverTimeDb
    {
        public Nullable<int> PreviousVisit { get; set; }
        public DateTime Month { get; set; }
        public Nullable<int> CurrentVisit { get; set; }
    }

    public class CategoryDb
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        //public string ID { get; set; }
    }

    public class RegionDb
    {
        public string Name { get; set; }
    }

    public class SegmentDb
    {
        public string Name { get; set; }
    }

    public class CustomerOverTimeDb
    {
        public double NotActive { get; set; }
        public double Active { get; set; }
        public double Previous { get; set; }
        public DateTime Month { get; set; }
    }
    public class Top10SKUs
    {
        public string Product_Name { get; set; }
        public double CurrSales { get; set; }
        public double Growth { get; set; }
    }

    public class SKUSparklineAllData
    {
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public double sales { get; set; }
    }
    public class SKUSparklineSales
    {
        public DateTime OrderDate { get; set; }
        public double sales { get; set; }
    }
    public class SKUNameSparklineSales
    {
        public string SkuName { get; set; }
        public List<SKUSparklineSales> sales { get; set; }
    }

    public class OrdersDb
    {
        public int Orders { get; set; }
        public decimal Rev_Growth { get; set; }
    }

    public class OrdersPerCustomerDb
    {
        public int orders { get; set; }

        public decimal Rev_Growth { get; set; }
    }

    public class Customers
    {
        public int customer { get; set; }
        public decimal Rev_Growth { get; set; }
    }

    public class Top5Customers
    {
        public string Customer_Name { get; set; }
        public double NoOfCust { get; set; }
        public decimal Growth { get; set; }
    }
    public class CustSparklineAllData
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double NoOfCust { get; set; }
    }
    public class CustSparklineSales
    {
        public DateTime OrderDate { get; set; }
        public int NoOfCust { get; set; }
    }
    public class CustNameSparklineSales
    {
        public string CustomerName { get; set; }
        public List<CustSparklineSales> NoOfCust { get; set; }
    }

    public class VisitDb
    {
        public int visitcount { get; set; }

        public decimal Rev_growth { get; set; }
    }

    

    public class SqlDataAccess
    {
        DashboardContext cs = new DashboardContext();

        public string StartDatesql;
        public string EndDatesql;
        public string PrevStartDatesql;
        public string PrevEndDatesql;
        //public DateTime? StartDate { get; set; } = new DateTime(2017, 01, 01);
        //public DateTime? EndDate { get; set; } = new DateTime(2017, 02, 01);

        string Filter = string.Empty;

        public void FilterCreation(string[] Category, string[] region, string[] segment)
        {
            Filter = "";
            if(Category != null)
            {
                for (int i = 0; i < Category.Length; i++)
                {
                    if (i < 1)
                    {
                        Filter += "and [Sub-Category] in (";
                        Filter += "'";
                        Filter += Category[i].Replace("'", "''") + "',";
                    }
                    else
                    {
                        Filter += "'";
                        Filter += Category[i].Replace("'", "''") + "',";
                    }
                }
                Filter = Filter.TrimEnd(',');
                Filter += ")";
            }
            if(region != null)
            {
                for (int i = 0; i < region.Length; i++)
                {
                    if (i < 1)
                    {
                        Filter += "and [Region] in (";
                        Filter += "'";
                        Filter += region[i].Replace("'", "''") + "',";
                    }
                    else
                    {
                        Filter += "'";
                        Filter += region[i].Replace("'", "''") + "',";
                    }
                }
                Filter = Filter.TrimEnd(',');
                Filter += ")";
            }
            if (segment != null )
            {
                for (int i = 0; i < segment.Length; i++)
                {
                    if (i < 1)
                    {
                        Filter += "and [Segment] in (";
                        Filter += "'";
                        Filter += segment[i].Replace("'", "''") + "',";
                    }
                    else
                    {
                        Filter += "'";
                        Filter += segment[i].Replace("'", "''") + "',";
                    }
                }
                Filter = Filter.TrimEnd(',');
                Filter += ")";
            }

        }

        public void SetDate(DateTime? StartDate, DateTime? EndDate)
        {
            this.StartDatesql = StartDate?.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture);
            this.EndDatesql = EndDate?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            int dtdiff = (int)(StartDate - EndDate).GetValueOrDefault().TotalDays;
            this.PrevStartDatesql = StartDate?.AddDays(dtdiff).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.PrevEndDatesql = StartDate?.AddDays(-1).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }



        public List<OrderbyValue> GetOrder()
        {
            //var query = cs.Orders.FromSqlRaw("select Sales,count([Order ID]) as ordecount FROM [VMP.Dashboard].[dbo].[Orders] group by Sales");

            //OrderbyValue list = new OrderbyValue { order = query.Sales, ordercount = query.}

            //return query;   

            return Helper.RawSqlQuery("select Sales,count([Order ID]) as ordecount FROM [VMP.Dashboard].[dbo].[Orders] where [Order Date] between '"+ StartDatesql+"' and '"+EndDatesql+"' " + Filter +"group by Sales",
                                    x => new OrderbyValue { order = (double)x[0], ordercount = (int)x[1] }).ToList();

        }

        public List<RevenueOverTime1> GetRevenueOverTimes()
        {

            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');

            //return Helper.RawSqlQuery("select a.MonthDate ,Sum(CurrentRevenue) CurrentRevenue, Sum(b.Prev) Prev from " +
            //"(select sum(case when[Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + " then Sales else 0 end) as CurrentRevenue," +
            // "MonthDate from [VMP.Dashboard].[dbo].[Orders]  group by MonthDate,[Order Date],[Sub-Category] having [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " +
            // ") a  left join(  select sum(case when[Order Date] between DATEADD(DAY, -30, '" + StartDatesql + "') and DATEADD(DAY, -30, '" + EndDatesql + "') " + Filter + " then Sales else 0 end) as Prev," +
            // "MonthDate from [VMP.Dashboard].[dbo].[Orders]  group by MonthDate ,[Sub-Category] having MonthDate < '" + StartDatesql + "') b " +
            // "on DATEPART(DAY, a.MonthDate) = datepart(DAY, b.MonthDate) group by  a.MonthDate Order By  a.MonthDate", x => new RevenueOverTime1 { Month = (DateTime)x[0], CurrentSeriesValue = x[1] == DBNull.Value ? 0 : (Nullable<double>)x[1], PreviousSeriesValue = x[2] == DBNull.Value ? 0 : (Nullable<double>)x[2] }).ToList();

            return Helper.RawSqlQuery("select c.MonthDate, c.CurrentRevenue, p.Prev from (" +
            "(select row_number() over(order by MonthDate) as id, sum(Sales) as CurrentRevenue, MonthDate" +
                " from [VMP.Dashboard].[dbo].[Orders] where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + "group by MonthDate" +
                ")c inner join ( select row_number() over(order by MonthDate) as id, sum(Sales) as Prev, MonthDate" +
                " from [VMP.Dashboard].[dbo].[Orders] where [Order Date] between '" + PrevStartDatesql + "' and '" + PrevEndDatesql + "' " + Filter + " group by MonthDate ) p on c.id=p.id " +
                ") order by MonthDate", x => new RevenueOverTime1 { Month = (DateTime)x[0], CurrentSeriesValue = x[1] == DBNull.Value ? 0 : (Nullable<double>)x[1], PreviousSeriesValue = x[2] == DBNull.Value ? 0 : (Nullable<double>)x[2] }).ToList();
        }

        public List<MyPieChartModelDb> GetMyPieChartModels()
        {
            //string cat = string.Empty;
            //for(int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');
            var datalist = Helper.RawSqlQuery(@" select Category,sum(Sales) as sale from [dbo].[Orders] where [Order Date]  between '" +  StartDatesql + "' and '" + EndDatesql + "' " + Filter + "group by Category", x => new MyPieChartModelDb { SegmentName = (string)x[0], SegmentValue = (double)x[1] }).ToList();

            int i = 0;
            string[] colors = { "#816aae", "#d682b6", "#f9956b", "#fec578", "#5e8ac7" };
            foreach (var item in datalist)
            {
                item.fill = colors[i];
                i++;
            }
            return datalist;
            //return Helper.RawSqlQuery(@" select Category,sum(Sales) as sale from [dbo].[Orders] group by Category",
            //                            x => new MyPieChartModelDb { SegmentName = (string)x[0], SegmentValue = (double)x[1], fill = "#df7c82" }).ToList();
        }



        //public List<TrafficModelDb> GetTraffics()
        public List<OrderbyPricebucket> GetOrderbyPricebucket()
        {
            var datalist = Helper.RawSqlQuery(@"Select bucketRank,[PriceBucket], count([Order ID]) as Sales from dbo.Orders 
                                                where [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"' " + Filter + @" group by bucketRank,PriceBucket order by bucketRank",
                                      x => new OrderbyPricebucket { Pricebucket = (string)x[1], ordercount = (int)x[2] }).ToList();

            return datalist;
        }

        public List<OrderOverTimeDb> GetOrderOverTimes()
        {

            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');
            return Helper.RawSqlQuery(@"select a.MonthDate,sum(Curr) as curr,sum(b.Prev) as prev from 
                        (select row_number() over(order by MonthDate) as id, count([Order ID]) as Curr, MonthDate 
				            from [dbo].[Orders] where [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"' " + Filter + @" group by MonthDate) a  
                        inner join 
                         (select row_number() over(order by MonthDate) as id,count([Order ID]) as Prev , MonthDate 
				            from [dbo].[Orders] Where [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" group by MonthDate) b on a.id = b.id
                              group by a.MonthDate", x => new OrderOverTimeDb { Month = (DateTime)x[0], CurrentOrder = x[1] == DBNull.Value ? 0 : (Nullable<int>)x[1], PreviousOrder = x[2] == DBNull.Value ? 0 : (Nullable<int>)x[2] }).ToList();


            //return Helper.RawSqlQuery(@"select a.MonthDate,sum(Curr) as curr,sum(b.Prev) as prev from 
            //(select count(distinct(case when [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + "then [Order ID] end)) as Curr,"+
            //" MonthDate from [dbo].[Orders] group by MonthDate,[Order Date] having [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "') a  left join " +
            // "(select count(distinct(case when [Order Date] between DATEADD(DAY, -30, '" + StartDatesql + "') and DATEADD(DAY, -30, '" + EndDatesql + "') " + Filter + "then [Order ID] end)) as Prev ,MonthDate from [dbo].[Orders]" +
            // "group by "+
            // "MonthDate having MonthDate < '" + StartDatesql + "') b on DATEPART(DAY, a.MonthDate) = datepart(DAY, b.MonthDate)  group by  a.MonthDate Order By  a.MonthDate", x => new OrderOverTimeDb { Month = (DateTime)x[0], CurrentOrder = x[1] == DBNull.Value ? 0 : (Nullable<int>)x[1], PreviousOrder = x[2] == DBNull.Value ? 0 : (Nullable<int>)x[2] }).ToList();
        }

        public List<DeviceTypeDb> GetDeviceType()
        {
            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');
            var datalist = Helper.RawSqlQuery(@"select TOP 4 [Sub-Category],COUNT([Customer ID]) as Customer FROM [VMP.Dashboard].[dbo].[Orders]  where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter +
                                           "group by [Sub-Category]", x => new DeviceTypeDb { Subbcategory = (string)x[0], CustomerCount = (int)x[1] });
            
            int i = 0;
            string[] colors = { "#816aae", "#d682b6", "#f9956b", "#fec578" };
            foreach (var item in datalist)
            {
                item.fill = colors[i];
                i++;
            }
            return datalist;

        }

        public List<TrafficSourceDb> GetTrafficSource()
        {
            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');

            var datalist = Helper.RawSqlQuery(@"select Region,COUNT([Customer ID]) as Customer FROM [VMP.Dashboard].[dbo].[Orders]   where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + "group by Region", x => new TrafficSourceDb { Region = (string)x[0], CustomerCount = (int)x[1] }).ToList();


            int i = 0;
            string[] colors = { "#816aae", "#d682b6", "#f9956b", "#fec578" };
            foreach (var item in datalist)
            {
                item.fill = colors[i];
                i++;
            }
            return datalist;
        }

        public List<VisitOverTimeDb> GetVisitOverTimes()
        {
            return Helper.RawSqlQuery(@"select a.MonthDate,sum(Curr) as curr, sum(b.Prev) as prev from 
                                    (select row_number() over(order by MonthDate) as id,count([Customer ID]) as Curr, MonthDate 
				                        from [dbo].[Orders] where [Order Date]  between '" + StartDatesql + @"' and '" + EndDatesql + @"' " + Filter + @" group by MonthDate
                                     ) a  
			                         inner join 
			                         (select row_number() over(order by MonthDate) as id,count([Customer ID]) as Prev, MonthDate 
				                        from [dbo].[Orders]  where [Order Date]  between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" group by MonthDate) b
                                     on a.id = b.id group by  a.MonthDate", x => new VisitOverTimeDb { Month = (DateTime)x[0], CurrentVisit = x[1] == DBNull.Value ? 0 : (Nullable<int>)x[1], PreviousVisit = x[2] == DBNull.Value ? 0 : (Nullable<int>)x[2] }).ToList();

            //return Helper.RawSqlQuery(@"select a.MonthDate,sum(Curr) as curr, sum(b.Prev) as prev from 
            //(select count(case when [Order Date]  between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @" then [Customer ID] end) as Curr,
            // MonthDate from[VMP.Dashboard].[dbo].[Orders]  group by MonthDate,[Order Date] having [Order Date]  between '" + StartDatesql + "' and '" + EndDatesql + @"'
            // ) a  left join (select count(case when[Order Date] between DATEADD(DAY, -30, '" + StartDatesql + @"') and DATEADD(DAY, -30, '" + EndDatesql + @"')  " + Filter + @" then [Customer ID] end) as Prev,
            // MonthDate from [VMP.Dashboard].[dbo].[Orders]  group by MonthDate having MonthDate < '" + StartDatesql + @"' ) b
             //on DATEPART(DAY, a.MonthDate) = datepart(DAY, b.MonthDate) group by  a.MonthDate Order By  a.MonthDate", x => new VisitOverTimeDb { Month = (DateTime)x[0], CurrentVisit = x[1] == DBNull.Value ? 0 : (Nullable<int>)x[1], PreviousVisit = x[2] == DBNull.Value ? 0 : (Nullable<int>)x[2] }).ToList();
        }

        public List<totalsales> GetTotalsales()
        {

            return Helper.RawSqlQuery(@"select b.curr,ISNULL(round((curr - prev)/NULLIF(prev,0),2),0) as Rev_Growth from (select round(sum(case when [Order Date]  between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then Sales else 0 end),1) as curr, 
                                            round(sum(case when [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then Sales else 0 end),1) as prev from dbo.Orders) b ",
                                   x => new totalsales { sales = x[0] == DBNull.Value ? 0 : (double)x[0] , Rev_Growth = x[1] == DBNull.Value ? 0 : (double)x[1] } ).ToList();

        }

        public List<productListed> GetProductListedb()
        {
            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');
            return Helper.RawSqlQuery(@"select b.ListedProducts, ISNULL(round((cast(b.ListedProducts as decimal) - cast(b.prev as decimal))/NULLIF(cast(b.prev as decimal),0),2),0)*100  as Rev_Growth 
                                        from (select Count(distinct(case when [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then [Product ID] end)) as ListedProducts,
                                        count(distinct(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Product ID] end)) as prev 
                                        from dbo.Orders) b",
                                   x => new productListed { product = x[0] == DBNull.Value ? 0 : (int)x[0], Rev_Growth = x[1] == DBNull.Value ? 0: (decimal)x[1] }).ToList();

        }

        public List<CustomerPieDb> GetCustomerspie()
        {
            var datalist = Helper.RawSqlQuery(@"Select Sum(t1.CurrSales) CurrSales
	                                           ,(CASE WHEN t3.Customer_Name IS NOT NULL THEN 'New' ELSE 'Repeat' END) as Customers
                                        From
                                        (Select O1.[Customer Name] as Customer_Name, Sum(Sales) as CurrSales
	                                        from dbo.Orders O1
	                                        Where [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @"
	                                        Group BY O1.[Customer Name]) t1
                                        Left join
                                        (Select * From(
	                                        Select O1.[Customer Name] as Customer_Name
	                                        from dbo.Orders O1
	                                        Where [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @"
                                        EXCEPT
	                                        Select O2.[Customer Name] as Customer_Name
	                                        from dbo.Orders O2
	                                        Where [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @"
                                        ) t2 ) t3
                                        on t1.Customer_Name = t3.Customer_Name
                                        Group By (CASE WHEN t3.Customer_Name IS NOT NULL THEN 'New' ELSE 'Repeat' END)",
                                        x => new CustomerPieDb { CustomerValue = x[0] == DBNull.Value ? 0 : (double)x[0], CustomerName = (string)x[1] }).ToList();

            int i = 0;
            string[] colors = { "#d682b6", "#5ea5c7"};
            foreach (var item in datalist)
            {
                item.fill = colors[i];
                i++;
            }

            return datalist;
        }

        public List<OrdersDb> GetOrders()
        {
            return Helper.RawSqlQuery(@"select b.ordersCurr, 
	                                    ISNULL(round((cast(b.ordersCurr as decimal) - cast(b.Ordersprev as decimal))/NULLIF(cast(b.Ordersprev as decimal),0),2),0) as Rev_Growth 
                                    from 
	                                    (select Count(distinct(case when [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then [Order ID] end)) as ordersCurr,
	                                    count(distinct(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Order ID] end)) as Ordersprev
	                                    from dbo.Orders) b",
                                    x => new OrdersDb { Orders = x[0] == DBNull.Value ? 0 : (int)x[0], Rev_Growth = x[1] == DBNull.Value ? 0 : (decimal)x[1] }).ToList();
        }

        public List<OrdersPerCustomerDb> GetOrdersPerCustomers()
        {
            return Helper.RawSqlQuery(@"select orders/customer as [order per customer] 
	                                        ,ISNULL(round(((CAST(b.orders as decimal)/CAST(b.customer as decimal)) - (CAST(b.Ordersprev as decimal)/CAST(b.customerPrev as decimal)))/
	                                        NULLIF((CAST(b.Ordersprev as decimal)/CAST(b.customerPrev as decimal)),0),2),0) as rev_growth
                                        from (select Count(case when [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then [Order ID] end) as orders 
			                                        ,Count(case when [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then [Customer Name] end) as customer
			                                        ,count(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Order ID] end) as Ordersprev,
			                                         count(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Customer Name] end) as customerPrev 
                                        from dbo.Orders) b",
                                        x => new OrdersPerCustomerDb { orders = x[0] == DBNull.Value ? 0 : (int)x[0], Rev_Growth = x[1] == DBNull.Value ? 0 : (decimal)x[1] }).ToList();
        }

        public List<Customers> GetCustomers()
        {
            return Helper.RawSqlQuery(@"select b.customerCurr
	                                        ,ISNULL(round((cast(b.customerCurr as decimal) - cast(b.customerPrev as decimal))/NULLIF(cast(b.customerPrev as decimal),0),2),0) as Rev_Growth 
                                        from 
	                                        (select Count(case when [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" then [Customer ID] end) as customerCurr,
	                                        count(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Customer ID] end) as customerPrev
	                                        from dbo.Orders) b",
                                            x => new Customers { customer = x[0] == DBNull.Value ? 0 : (int)x[0], Rev_Growth = x[1] == DBNull.Value ? 0 : (decimal)x[1] }).ToList();
        }
        public List<CategoryDb> GetCategoryDbs()
        {
            return Helper.RawSqlQuery(@"select Category,[Sub-Category] from [dbo].[Orders] group by Category,[Sub-Category]",
                x => new CategoryDb { Category = (string)x[0], SubCategory = (string)x[1] }).ToList();
        }

        public List<RegionDb> GetRegions()
        {
            return Helper.RawSqlQuery(@"select [Region] from [VMP.Dashboard].[dbo].[Orders] group by Region",
                                       x => new RegionDb { Name = (string)x[0] }).ToList();
        }
        public List<SegmentDb> GetSegment()
        {
            return Helper.RawSqlQuery(@"select [Segment] from [VMP.Dashboard].[dbo].[Orders] group by [Segment]",
                                       x => new SegmentDb { Name = (string)x[0] }).ToList();
        }

        public List<CustomerOverTimeDb> GetCustomerOverTimes()
        {
            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');

            return Helper.RawSqlQuery(@"Select MonthDate, SUM(Active_Customers) Active_Customers, SUM(NotActive_Customers) NotActive_Customers, SUM(PrevSales) PrevSales 
                                        From 
	                                        (Select t1.MonthDate as MonthDate ,t1.Customer_Name ,t3.Customer_Name as t3cust,t1.CurrSales,
		                                        (CASE WHEN t3.Customer_Name IS NOT NULL THEN t1.CurrSales ELSE 0 END) as Active_Customers 
		                                        ,(CASE WHEN t3.Customer_Name IS NULL THEN t1.CurrSales ELSE 0 END) as NotActive_Customers ,PrevSales 
	                                        From 
		                                        (Select O1.MonthDate,O1.[Customer Name] as Customer_Name, count([Customer ID]) as CurrSales 
		                                        from dbo.Orders O1 Where [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @" Group BY O1.MonthDate, O1.[Customer Name]) t1 
		                                        Left join 
		                                        (Select * From(
			                                        Select O1.[Customer Name] as Customer_Name from dbo.Orders O1 Where 
			                                        [Order Date] between '" + StartDatesql + @"' and '" + EndDatesql + @"'  " + Filter + @"
		                                         EXCEPT 
			                                        Select O2.[Customer Name] as Customer_Name from dbo.Orders O2 Where 
			                                        [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @"
			                                        ) t2 
		                                         ) t3 on t1.Customer_Name = t3.Customer_Name
		                                         Left join 
		                                         (Select O3.MonthDate,O3.[Customer Name] as Customer_Name, count([Customer ID]) as PrevSales from dbo.Orders O3 
			                                        Where O3.[Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @"
			                                        Group BY O3.MonthDate,O3.[Customer Name])t4	
	                                        on t1.Customer_Name = t4.Customer_Name) t5 Group by MonthDate Order By MonthDate",
                                            x => new CustomerOverTimeDb { Month = (DateTime)x[0], Active = x[1] == DBNull.Value ? 0 : (int)x[1], NotActive = x[2] == DBNull.Value ? 0 : (int)x[2], Previous = x[3] == DBNull.Value ? 0 : (int)x[3] }).ToList();
        }

        public List<Top10SKUs> GetTop10SKUs()
        {
            //string cat = string.Empty;
            //for (int j = 0; j < arr.Length; j++)
            //{
            //    cat += "'";
            //    cat += arr[j] + "',";
            //}
            //cat = cat.TrimEnd(',');
            return Helper.RawSqlQuery(@"Select TOP(10) T1.Product_Name, Round(CurrSales,1) as CurrSales, PrevSales, Round(ISNULL((CurrSales/NULLIF(PrevSales,0))-1,1) *100,2) as change
                                        From
                                        (Select O1.[Product Name] as Product_Name, Sum(Sales) as CurrSales
                                        from dbo.Orders O1
                                        Where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                        Group BY O1.[Product Name]) T1
                                        Left Join
                                        (Select O2.[Product Name] as Product_Name, Sum(Sales) as PrevSales
                                        from dbo.Orders O2
                                        Where  [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @"
                                        Group BY O2.[Product Name]) T2
                                        On t1.Product_Name = t2.Product_Name
                                        Order by CurrSales Desc", x => new Top10SKUs { Product_Name = (string)x[0], CurrSales = x[1] == DBNull.Value ? 0 : (double)x[1], Growth = (double)x[3] }).ToList();
        }




        public List<SKUSparklineAllData> GetTop10SKUsSparkline(string sku)
        {

            //List<SKUSparklineAllData> SparlineAllData = 

            sku = sku.Replace("'", "''");


            return Helper.RawSqlQuery(@"Select [Product Name],MonthDate, SUM(Sales) Sales
                                    from dbo.Orders
                                    where [Product Name] in ('" + sku + @"'-- and [Order Date] between '2017-02-01' and '2017-02-28'
                                    --Select TOP(10) T1.Product_Name
                                    --From(
                                    --Select O1.[Product Name] as Product_Name, Sum(Sales) as CurrSales
                                    --from dbo.Orders O1
                                    --Where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                    --Group BY O1.[Product Name]
                                    --) t1
                                    --Order by CurrSales desc
                                    )
                                    and [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                    group by [Product Name],MonthDate
                                    Order by [Product Name],MonthDate", x => new SKUSparklineAllData { ProductName = (string)x[0], OrderDate = (DateTime)x[1], sales = (double)x[2] }).ToList();

            //var ProductsList = SparlineAllData.GroupBy(p => p.ProductName).Select(grp => grp.First()).ToList();
            //List<SKUNameSparklineSales> SparkLineData = new List<SKUNameSparklineSales>();
           
            //foreach (var item in ProductsList)
            //{
            //    List<SKUSparklineSales> Salesdb = new List<SKUSparklineSales>();
            //    foreach (var value in SparlineAllData)
            //    {
            //        if (item.ProductName == value.ProductName)
            //        {
            //            Salesdb.Add(new SKUSparklineSales { OrderDate = value.OrderDate, sales = value.sales });
            //        }
            //    }
            //    SparkLineData.Add(new SKUNameSparklineSales { SkuName = item.ProductName, sales = Salesdb });
            //}

            //return SparkLineData.ToList();
        }

        public List<Top5Customers> GetTop5Customers()
        {
            return Helper.RawSqlQuery(@"Select TOP(5) T1.Customer_Name, Curr_Cust_Cnt, Prev_Cust_Cnt, (ISNULL((Cast(Curr_Cust_Cnt as decimal)/NULLIF(Cast(Prev_Cust_Cnt as decimal),0))-1,1) *100) as change  
                                        From
                                        (Select O1.[Customer Name] as Customer_Name, sum(Sales) as Curr_Cust_Cnt
                                        from dbo.Orders O1
                                        Where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                        Group BY O1.[Customer Name]) T1
                                        Left Join
                                        (Select O2.[Customer Name] as Customer_Name, sum(Sales) as Prev_Cust_Cnt
                                        from dbo.Orders O2
                                        Where [Order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @"
                                        Group BY O2.[Customer Name]) T2
                                        On t1.Customer_Name = t2.Customer_Name
                                        Order by Curr_Cust_Cnt Desc",
                                        x => new Top5Customers { Customer_Name = (string)x[0], NoOfCust = (double)x[1], Growth = (decimal)x[3] }).ToList();
        }

        public List<CustSparklineAllData> GetTop5CustSparkline(string custname)
        {
            //List<CustSparklineAllData> SparklineAllData =
            custname = custname.Replace("'", "''");

                return Helper.RawSqlQuery(@"Select [Customer Name],MonthDate, sum(Sales) as NoOfCust
                                        from dbo.Orders
                                        where [Customer Name] in ('" + custname + @"'
                                        --Select TOP(5) T1.Customer_Name
                                        --From
                                        --(Select O1.[Customer Name] as Customer_Name, Count([Customer ID]) as Curr_Cust_Cnt
                                        --from dbo.Orders O1
                                        --Where [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                        --Group BY O1.[Customer Name]) T1
                                        --Order by Curr_Cust_Cnt desc
                                        )  
                                        and [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @"
                                        group by [Customer Name],MonthDate
                                        Order by [Customer Name],MonthDate", x => new CustSparklineAllData { CustomerName = (string)x[0], OrderDate = (DateTime)x[1], NoOfCust = (double)x[2] }).ToList();



            //var CustomersList = SparklineAllData.GroupBy(p => p.CustomerName).Select(grp => grp.First()).ToList();

            //List<CustNameSparklineSales> SparkLineData = new List<CustNameSparklineSales>();

            //foreach (var item in CustomersList)
            //{
            //    List<CustSparklineSales> Salesdb = new List<CustSparklineSales>();
            //    foreach (var value in SparklineAllData)
            //    {
            //        if (item.CustomerName == value.CustomerName)
            //        {

            //            Salesdb.Add(new CustSparklineSales { OrderDate = value.OrderDate, NoOfCust = value.NoOfCust });
            //        }
            //    }
            //    SparkLineData.Add(new CustNameSparklineSales { CustomerName = item.CustomerName, NoOfCust = Salesdb });
            //}
            //return SparkLineData.ToList();
        }

        public List<VisitDb> GetVisitDbs()
        {
            return Helper.RawSqlQuery(@"select b.customerCurr
	                                    ,ISNULL(round((cast(b.customerCurr as decimal) - cast(b.customerPrev as decimal))/NULLIF(cast(b.customerPrev as decimal),0),2),0) *100 as Rev_Growth
                                    from 
	                                    (select Count(distinct(case when [Order Date] between '" + StartDatesql + "' and '" + EndDatesql + "' " + Filter + @" then [Customer ID] end)) as customerCurr,
	                                    count(distinct(case when [order Date] between '" + PrevStartDatesql + @"' and '" + PrevEndDatesql + @"' " + Filter + @" then [Customer ID] end)) as customerPrev
	                                    from dbo.Orders) b",
                                    x => new VisitDb { visitcount = x[0] == DBNull.Value ? 0 : (int)x[0], Rev_growth = x[1] == DBNull.Value ? 0 : (decimal)x[1] }).ToList();
        }

    }
    
   

    public static class Helper
    {
        public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var context = new DashboardContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 10000;
                    context.Database.OpenConnection();
                    
                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();

                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }

                        return entities;
                    }
                }
            }
        }
    }
}
