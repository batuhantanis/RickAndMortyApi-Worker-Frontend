﻿namespace egebilgi_worker.Core.Responses;

public class LocationRawResponse
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string dimension { get; set; }
    public List<string> residents { get; set; }
    public string url { get; set; }
    public DateTime created { get; set; }
}