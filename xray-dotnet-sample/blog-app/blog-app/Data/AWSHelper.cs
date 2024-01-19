using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;

namespace blog_app.Data;

public class AWSHelper
{

    private AWSCredentials _credentials;
    private AmazonS3Client _s3Client;
    private AmazonSQSClient _amazonSQSClient;
    private IConfiguration _configuration;

    public AWSHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        ConfigClient();
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
            _s3Client = new AmazonS3Client(_credentials, Amazon.RegionEndpoint.USEast1);
            _amazonSQSClient = new AmazonSQSClient(_credentials, Amazon.RegionEndpoint.USEast1);
        }
        else
        {
            _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
            _amazonSQSClient = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);
        }
    }

    public async Task<byte[]> GetImageFromS3Bucket(string bucketName, string imageName)
    {
        var req = new GetObjectRequest { BucketName = bucketName, Key = imageName };
        GetObjectResponse response = await _s3Client.GetObjectAsync(req);

        //await response.WriteResponseStreamToFileAsync(Environment.CurrentDirectory + "/wwwroot/images/ad/Downloaded.png",false,CancellationToken.None);
        //string image = Environment.CurrentDirectory + "/wwwroot/images/ad/Downloaded.png";

        await response.WriteResponseStreamToFileAsync(@"C:\Windows\Temp\Downloaded.png", false, CancellationToken.None);
        string image = @"C:\Windows\Temp\Downloaded.png";

        byte[] imageBinary = System.IO.File.ReadAllBytes(image);
        return imageBinary;
    }

    public void AddMessageToSQS(string serviceUrl, string clientIP)
    {

        var userLog = "{'User ip':'" + clientIP + "','TimeStamp':'" + DateTime.Now.ToString() + "' }";
        SendMessageRequest sendRequest = new SendMessageRequest(serviceUrl, userLog);
        var result = _amazonSQSClient.SendMessageAsync(sendRequest).Result;
    }


}
