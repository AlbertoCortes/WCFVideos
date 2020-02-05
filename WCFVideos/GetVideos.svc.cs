using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace WCFVideos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetVideos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetVideos.svc or GetVideos.svc.cs at the Solution Explorer and start debugging.
    public class GetVideos : IGetVideos
    {
       public List<Videos> ObtenerVideos(string name)
        {
            List<Videos> videos = new List<Videos>();
            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyBhqe3OaIZT7RusiHlV_kBL3z2CExG3Vb4",
                ApplicationName = "Rockola-264715"
            });
            SearchResource.ListRequest searchListRequest = youtube.Search.List("snippet");
            searchListRequest.Q = name;
            searchListRequest.MaxResults = 40;
            SearchListResponse searchListResponse = searchListRequest.Execute();
            foreach (var item in searchListResponse.Items)
            {
                if (item.Id.Kind == "youtube#video")
                {
                    videos.Add(new Videos
                    {
                        ID= item.Id.VideoId,
                        Nombre = item.Snippet.Title,
                        Url = "https://www.youtube.com/embed/" + item.Id.VideoId,
                        Thumbnail = "http://img.youtube.com/vi/" + item.Id.VideoId + "/hqdefault.jpg"
                    });
                }
            }
            return videos;
        }
    }
}
