using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomework1
{
    public class Sum
    {
        public int[] FieldSumInGroupByRowCount<T>(int rowCount, string fieldName, IEnumerable<T> data)
        {
            if (data == null || data.Count() == 0)
                return new int[] { };

            Type type = typeof(T);
            var propertyInfo = type.GetProperty(fieldName);

            List<int> resultData = new List<int>();
            int calCount = 0;
            int sum=0;
            foreach (var item in data)
            {
                sum += (int)propertyInfo.GetValue(item);
                calCount++;

                if (calCount == rowCount)
                {
                    resultData.Add(sum);
                    calCount = 0;
                    sum = 0;
                }
            }
            if (calCount != 0)
                resultData.Add(sum);

            return resultData.ToArray();
        }
    }
}
