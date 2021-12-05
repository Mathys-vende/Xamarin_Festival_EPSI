using plz.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plz.Services
{
    internal interface IProgrammationStore<T>
    {
        Task<bool> AddProgrammation(T programmation);
        Task<bool> DeleteProgrammation(int id);
        Task<List<T>> GetProgrammations(bool forceRefresh = false);
        Task<T> GetProgrammation(int id);
    }
}
