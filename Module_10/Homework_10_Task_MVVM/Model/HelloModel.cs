using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Homework_10_Task_MVVM.Model
{
    internal class HelloModel
    {

        private List<string> repositoryData;
        public string ImportantInfo
        {
            get
            {
                return SummarizedData(repositoryData);
            }
        }

        private string SummarizedData(List<string> dataList)
        {
            string importantInfo = dataList.ElementAt(0) + ", " + dataList.ElementAt(1) + "!";
            return importantInfo;
        }

        public HelloModel()
        {
            repositoryData = GetData();
        }

        private List<string> GetData()
        {
            repositoryData = new List<string>()
            {
                "Hello",
                "Model"
            };

            return repositoryData;
        }
    }
}
