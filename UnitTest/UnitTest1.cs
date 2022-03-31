using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_Test.Controllers;
using API_Test.Models;
using System;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1 : ApiController
    {

        //1. The maximum amount per day and vehicle is 60 SEK.
        [TestMethod] //Failure
        [Ignore]
        public void MaximumAmount60sekF()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 07:30:00")),// 18
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 09:50:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 10:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 12:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 13:05:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 14:51:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 16:30:00")),// 18 
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 17:55:00")),// 13 - sum = 105
            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreNotEqual(105, result);

        }

        [TestMethod] // Success
        [Ignore]
        public void MaximumAmount60sekS()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 07:30:00")),// 18
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 09:50:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 10:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 12:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 13:05:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 14:51:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 16:30:00")),// 18 
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 17:55:00")),// 13 - sum = 105
            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreEqual(60, result);
        }


        //2. The tax is not charged on weekends (Saturdays and Sundays),public
        //holidays, days before a public holiday and during the month of July.
        [TestMethod] //Failure
        [Ignore]
        public void IsNotChargedWeekendsF()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-05 06:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-06 07:30:00")),// 18
              new Historic(1, "car",Convert.ToDateTime("2013-01-12 08:40:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-13 09:50:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-19 10:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-20 12:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-26 13:05:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-07-10 14:51:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-07-15 16:30:00")),// 18 
              new Historic(1, "car",Convert.ToDateTime("2013-07-05 17:55:00")),// 13 - sum = 105
            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreNotEqual(105, result);
        }

        [TestMethod]//Success
        [Ignore]
        public void IsNotChargedWeekendsS()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-05 06:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-06 07:30:00")),// 18
              new Historic(1, "car",Convert.ToDateTime("2013-01-12 08:40:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-13 09:50:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-19 10:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-20 12:00:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-26 13:05:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-07-10 14:51:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-07-15 16:30:00")),// 18 
              new Historic(1, "car",Convert.ToDateTime("2013-07-05 17:55:00")),// 13 - sum = 105
            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreEqual(0, result);

        }


        //3. a vehicle that passes several tolling stations within 60 minutes is only taxed
        //once.The amount that must be paid is the highest one.
        [TestMethod]//Failure
        [Ignore]
        public void TheAmountHighestF()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:59:00")),// 13*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 09:50:00")),// 8*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 15:31:00")),// 18* sum = 63

            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreNotEqual(63, result);

        }

        [TestMethod]//Success
        [Ignore]
        public void TheAmountHighestS()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 06:59:00")),// 13*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 09:50:00")),// 8*
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(1, "car",Convert.ToDateTime("2013-01-15 15:31:00")),// 18* sum = 63

            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreEqual(47, result);

        }


        //4. Tax Exempt vehicles.
        [TestMethod]//Failure
        [Ignore]
        public void TaxExemptVehiclesF()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "Motorbike",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "Tractor",Convert.ToDateTime("2013-01-15 07:55:00")),// 18
              new Historic(1, "Emergency",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "Diplomat",Convert.ToDateTime("2013-01-15 10:50:00")),// 8
              new Historic(1, "Foreign",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(1, "Military",Convert.ToDateTime("2013-01-15 17:31:00")),// 13 sum = 63

            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreNotEqual(63, result);

        }

        [TestMethod]//Success
        [Ignore]
        public void TaxExemptVehiclesS()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleId = 1;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "Motorbike",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "Tractor",Convert.ToDateTime("2013-01-15 07:55:00")),// 18
              new Historic(1, "Emergency",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "Diplomat",Convert.ToDateTime("2013-01-15 10:50:00")),// 8
              new Historic(1, "Foreign",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(1, "Military",Convert.ToDateTime("2013-01-15 17:31:00")),// 13 sum = 63

            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleId);

            int result = TestInsert.GetTollFee();

            Assert.AreEqual(0, result);

        }


        //5. Different clients(vehicleId: client vehicle license plate)
        [TestMethod]//Failure
        [Ignore]
        public void DifferentClientsF()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();

            int vehicleIdI = 1;
            int vehicleIdII = 2;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 07:55:00")),// 18
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 10:50:00")),// 8
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 17:31:00")),// 13

              // Client 1 sum 34
              // client 2 sum  29

            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleIdII);

            int result = TestInsert.GetTollFee();

            Assert.AreNotEqual(63, result);

        }

        [TestMethod]//Success
        //[Ignore]
        public void DifferentClientsS()
        {
            API_Test.Controllers.HistoricController TestInsert = new API_Test.Controllers.HistoricController();
           
            int vehicleIdI = 1;
            int vehicleIdII = 2;

            List<Historic> Historic = new List<Historic> {

              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 06:20:00")),// 8
              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 07:55:00")),// 18
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 08:40:00")),// 8
              new Historic(1, "Car",Convert.ToDateTime("2013-01-15 10:50:00")),// 8
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 14:55:00")),// 8
              new Historic(2, "Car",Convert.ToDateTime("2013-01-15 17:31:00")),// 13

              // Client 1 sum 34
              // client 2 sum  29
            };

            for (int i = 0; i < Historic.Count; i++)
            {
                TestInsert.PostInsert(Historic[i].vehicleId, Historic[i].vehicleType, Historic[i].dates);
            }

            TestInsert.PostConsult(vehicleIdI);

            int result = TestInsert.GetTollFee();

            Assert.AreEqual(34, result);

        }

    }
}
