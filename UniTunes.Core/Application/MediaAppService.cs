using System;
using System.Collections.Generic;
using UniTunes.Core.Domain.Model;
using UniTunes.Core.Infra.Database;

namespace UniTunes.Core.Application
{
    public class MediaAppService
    {
        public MediaAppService()
        {

        }

        public Media Get(int id)
        {
            throw new NotImplementedException();
        }

        //TODO:Colocar os parametros necessarios
        public void Criar() 
        {
            throw new NotImplementedException();
        }

        public void Remover(int mediaId)
        {
            throw new NotImplementedException();
        }

        public void Editar(int mediaId)
        {
            throw new NotImplementedException();
        }

        public void Buy(int userId, int mediaId)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseByDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseByRange(DateTime begin, DateTime end)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalRevanue()
        {
            throw new NotImplementedException();
        }
    }
}
