using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

using System.IO;

namespace DigestKey
{

    class Program
    {
        static void Main(string[] args)
        {
            Data_Dig obj = new Data_Dig();

           // {"applNo":"525389319","applName":"MANMEET","transCode": "511","covCode": "4","rtoCode": "PB06","testDate": "24-04-2019","vehRegno":"PB10FF7606","testResult": "P","failReasonCode":"0","applnIdFromAgency":"525389319","agencyId":"PB0365","agentPwd":"FA576AF71380E6EEFBE24F8032CDCDF0","verifyData":"+QwZegJ2Gqk967RwuV4tunrEukY=","stCode":"PB"}


            string DigestKey = "knaqrbphwer6543"; //knaqrbphwer6543
            string Applicantion_num = "525389319";
            string Applicant_Name = "MANMEET";
            string transCode = "511";
            string covCode = "4";
            string Rto_code = "PB06";
            string Test_date = "24-04-2019";
            string test_restult = "P";
            string Reson = "0";
            string applnIdFromAgency = "525389319";
            string AgentId = "PB0365";
            
         //   applNo:applName:transCode:covCode:rtoCode:Test_date:"PB10FF7606":testResult:0:agencyId
         //   string strdata = Applicantion_num + ";" + Applicant_Name + ";" + transCode + ";" + covCode + ";" + Rto_code.ToString().Trim() + ";" + Test_date + ";" + "PB10FF7606" + ";" + test_restult + ";" + "0" + ";" + Applicantion_num + ";" + AgentId;

            string strdata = Applicantion_num + ";" + Applicant_Name + ";" + transCode + ";" + covCode + ";" + Rto_code.ToString().Trim() + ";" + Test_date + ";" + "PB10FF7606" + ";" + test_restult + ";" + Reson + ";" + applnIdFromAgency + ";" + AgentId;
                          
            
            string res = obj.GetBase64StringForMessageDigest( DigestKey,strdata);
        }

    }
    class Data_Dig
    {

      public  string GetBase64StringForMessageDigest(string DigestKey, string tmpVeriFyDATA)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(Encoding.ASCII.GetBytes(DigestKey));
            byte[] byteArray = Encoding.ASCII.GetBytes(tmpVeriFyDATA);
            MemoryStream stream = new MemoryStream(byteArray);
            byte[] hashValue = myhmacsha1.ComputeHash(stream);
            return Convert.ToBase64String(hashValue);
        }
    }
}
