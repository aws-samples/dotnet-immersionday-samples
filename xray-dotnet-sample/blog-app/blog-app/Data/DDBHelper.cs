using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Amazon.Runtime.CredentialManagement;
using System.IO;

namespace blog_app.Data;

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
            var chain = new CredentialProfileStoreChain();
            if (!chain.TryGetAWSCredentials(_configuration["AWSProfileName"], out AWSCredentials _credentials))
            {
                throw new InvalidDataException($"Unable to get credentials for profile {_configuration["AWSProfileName"]}");
            }
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

