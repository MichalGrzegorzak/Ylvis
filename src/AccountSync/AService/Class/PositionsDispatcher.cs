using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AServiceContract;
using log4net;

namespace AService
{
    public class PositionsDispatcher
    {
        private static readonly ILog log = LogManager.GetLogger("GuiLogger");
        private List<Position> _positionHistory = new List<Position>();

        public static bool ValidationEnabled = true;

        public bool ValidatePosition(Position position)
        {
            bool isOkey = true;
            if (_positionHistory.Count == 0)
            {
                _positionHistory.Add(position);
            }
            else
            {
                Position last = _positionHistory.Last();
                if (last.Direct == position.Direct)
                {
                    log.Error("Dispather => Signal should have different direction!");
                    isOkey = false;
                }

                //if(last.Date.AddMinutes(10) > position.Date)
                //{
                //    log.Error("Dispather => New signal should be at least 10 min later!");
                //    isOkey = false;
                //}
                    
                //3. allow max 3-4 changes in 1 day

            }

            return isOkey;
        }

        public void AddPosition(Position position)
        {
            _positionHistory.Add(position);
        }

        public bool AddIfValid(Position pos)
        {
            bool result = true;

            if (ValidationEnabled)
                result = ValidatePosition(pos);

            if(result)
                AddPosition(pos);

            return result;
        }
    }
}
