using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Homework_10_Task_MVVM.Model
{
    internal class HelloModel
    {

        //private List<string> repositoryData;
        private string repositoryData;


        public string ImportantInfo
        {
            get
            {
                return SummarizedData(repositoryData);
            }
        }

        //private string SummarizedData(List<string> dataList)
        private string SummarizedData(string dataList)
        {
            string importantInfo = dataList;
            return importantInfo;
        }

        public HelloModel()
        {
            repositoryData = GetData();
        }

        //private List<string> GetData()
        private string GetData()
        {
            repositoryData = "Hello Model";

            return repositoryData;
        }
    }
}
