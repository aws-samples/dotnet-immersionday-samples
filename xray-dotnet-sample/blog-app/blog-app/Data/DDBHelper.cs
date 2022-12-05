using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;

namespace blog_app.Data
{
    public class DDBHelper
    {
        private AWSCredentials _credentials;        
        private AmazonDynamoDBClient _ddbClient;
        private Table _ddbTable;
        IConfiguration _configuration;

        public DDBHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            ConfigClient();
            _ddbTable = Table.LoadTable(_ddbClient, _configuration["DynamoDBTable"]);
            
        }

        private void ConfigClient()
        {
            if (string.Equals(_configuration["Execute"], "Local", StringComparison.OrdinalIgnoreCase) == true)
            {
                _credentials = new Amazon.Runtime.StoredProfileAWSCredentials(_configuration["AWSProfileName"]);
                _ddbClient = new AmazonDynamoDBClient(_credentials, RegionEndpoint.USEast1);                 
            }
            else
                _ddbClient = new AmazonDynamoDBClient(RegionEndpoint.USEast1);
        }

        public Document GetItems(int id)
        {                        
            var item = _ddbTable.GetItemAsync(id).Result;            
            return item;
        }


        
    }
}
