using System;


namespace Coop.Data
{
    public class DateDto
    {
        public readonly Enums.DatePeriod _datePeriod;
        public readonly int _datePeriodValue;
        public readonly EventHandler _datePeriodTriggered=null;
        public static DateTime _date;
        public static DateTime _lastTriggeredDate;
        public DateDto(Enums.DatePeriod datePeriod,int datePeriodValue,EventHandler datePeriodTriggered)
        {
            _datePeriod=datePeriod;
            _datePeriodValue=datePeriodValue;
            _datePeriodTriggered=datePeriodTriggered;
        }
        public DateTime Date
        {
            get{return _date;}
            set
            {
                if (!_date.Equals(new DateTime()))
                {
                    if (_datePeriod==Enums.DatePeriod.Day && (value-_lastTriggeredDate).TotalDays>=_datePeriodValue)
                    {
                        _lastTriggeredDate=value;
                        _datePeriodTriggered?.Invoke(null,null);
                    }
                    else if (_datePeriod==Enums.DatePeriod.Week && Coop.Helper.DateHelper.WeekDifferenceBetweenTwoDate(_lastTriggeredDate,value)>=_datePeriodValue)
                    {
                        _lastTriggeredDate=value;
                        _datePeriodTriggered?.Invoke(null,null);
                    }
                    else if (_datePeriod==Enums.DatePeriod.Month && Coop.Helper.DateHelper.MonthDifferenceBetweenTwoDate(_lastTriggeredDate,value)>=_datePeriodValue)
                    {
                        _lastTriggeredDate=value;
                        _datePeriodTriggered?.Invoke(null,null);
                    }
                    else if (_datePeriod==Enums.DatePeriod.Year && Coop.Helper.DateHelper.YearDifferenceBetweenTwoDate(_lastTriggeredDate,value)>=_datePeriodValue)
                    {
                        _lastTriggeredDate=value;
                        _datePeriodTriggered?.Invoke(null,null);
                    }
                }
                _date=value;
            }
        }
    }
}
