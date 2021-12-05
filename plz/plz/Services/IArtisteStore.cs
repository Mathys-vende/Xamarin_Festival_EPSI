using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using plz.Models;

namespace plz.Services
{
    public interface IArtisteStore
    {
        Task<bool> AddArtiste(Artiste artiste);
        Task<bool> DeleteArtiste(int id);
        Task<List<Artiste>> GetArtistes();
        Task<Artiste> GetArtiste(int id);
    }
}
