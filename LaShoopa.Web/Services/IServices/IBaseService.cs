using LaShoopa.Web.Models;
using LaShoopa.Web.Models.DTOs;

namespace LaShoopa.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponceDTO ResponceModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
