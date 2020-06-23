using System;
using System.Collections.Generic;
using System.Text;

namespace TaskForTGWCSharp
{
    class Parameters
    {
        //Data Generation
        private int ordersPerHour;
        private bool ordersPerHourAvailable;
        private int ordersPerHourLayer;
        private int orderLinesPerOrder;
        private bool orderLinesPerOrderAvailable;
        private int orderLinesPerOrderLayer;

        //Shuttle System
        private string inboundStrategy;
        private bool inboundStrategyAvailable;
        private int inboundStrategyLayer;
        private int numberOfAisles;
        private bool numberOfAislesAvailable;
        private int numberOfAislesLayer;

        //System Config
        private string powerSupply;
        private bool powerSupplyAvailable;
        private int powerSupplyLayer;

        //Results
        private TimeSpan resultStartTime;
        private bool resultStartTimeAvailable;
        private int resultStartTimeLayer;
        private int resultInterval;
        private bool resultIntervalAvailable;
        private int resultIntervalLayer;

        public List<string> ConfigIds = new List<string> { "OrdersPerHour", "OrderLinesPerOrder", "InboundStrategy", "NumberOfAisles", "PowerSupply", "ResultStartTime", "ResultInterval"};

        public Parameters()
        {
            ordersPerHourAvailable = false;
            orderLinesPerOrderAvailable = false;
            inboundStrategyAvailable = false;
            numberOfAislesAvailable = false;
            powerSupplyAvailable = false;
            resultStartTimeAvailable = false;
            resultIntervalAvailable = false;
            
            ordersPerHourLayer = -1;
            OrderLinesPerOrderLayer = -1;
            InboundStrategyLayer = -1;
            NumberOfAislesLayer = -1;
            PowerSupplyLayer = -1;
            ResultStartTimeLayer = -1;
            ResultIntervalLayer = -1;
        }

        public int OrdersPerHour
        {
            get { return ordersPerHour; }
            set { ordersPerHour = value; ordersPerHourAvailable = true; }
        }

        public bool IsOrdersPerHourAvailable()
        {
            return ordersPerHourAvailable;
        }

        public int OrderLinesPerOrder
        {
            get { return orderLinesPerOrder; }
            set { orderLinesPerOrder = value; orderLinesPerOrderAvailable = true; }
        }

        public bool IsOrderLinesPerOrderAvailable()
        {
            return orderLinesPerOrderAvailable;
        }

        public string InboundStrategy
        {
            get { return inboundStrategy; }
            set { inboundStrategy = value; inboundStrategyAvailable = true; }
        }

        public bool IsInboundStrategyAvailable()
        {
            return inboundStrategyAvailable;
        }

        public int NumberOfAisles
        {
            get { return numberOfAisles; }
            set { numberOfAisles = value; numberOfAislesAvailable = true; }
        }

        public bool IsNumberOfAislesAvailable()
        {
            return numberOfAislesAvailable;
        }

        public string PowerSupply
        {
            get { return powerSupply; }
            set { powerSupply = value; powerSupplyAvailable = true; }
        }

        public bool IsPowerSupplyAvailable()
        {
            return powerSupplyAvailable;
        }

        public TimeSpan ResultStartTime
        {
            get { return resultStartTime; }
            set { resultStartTime = value; resultStartTimeAvailable = true; }
        }

        public bool IsResultStartTimeAvailable()
        {
            return resultStartTimeAvailable;
        }

        public int ResultInterval
        {
            get { return resultInterval; }
            set { resultInterval = value; resultIntervalAvailable = true; }
        }

        public int OrdersPerHourLayer
        {
            get { return ordersPerHourLayer; }
            set { ordersPerHourLayer = value; }
        }
        public int OrderLinesPerOrderLayer
        {
            get { return orderLinesPerOrderLayer; }
            set { orderLinesPerOrderLayer = value; }
        }
        public int InboundStrategyLayer
        {
            get { return inboundStrategyLayer; }
            set { inboundStrategyLayer = value; }
        }
        public int NumberOfAislesLayer
        {
            get { return numberOfAislesLayer; }
            set { numberOfAislesLayer = value; }
        }
        public int PowerSupplyLayer
        {
            get { return powerSupplyLayer; }
            set { powerSupplyLayer = value; }
        }
        public int ResultStartTimeLayer
        {
            get { return resultStartTimeLayer; }
            set { resultStartTimeLayer = value; }
        }
        public int ResultIntervalLayer
        {
            get { return resultIntervalLayer; }
            set { resultIntervalLayer = value; }
        }

        public bool IsResultIntervalAvailable()
        {
            return resultIntervalAvailable;
        }
    }
}
