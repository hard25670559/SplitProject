using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Setting;

namespace Core.Repository
{
    public class RepositoryFactory
    {

        public static IRepository Repository(Alias modelName)
        {
            IRepository respostory = null;

            Dictionary<Alias, Type> repositoryDictionary = Setting.RepositoryDictionary;

            respostory = repositoryDictionary[modelName].Assembly.CreateInstance(repositoryDictionary[modelName].FullName) as IRepository;
            
            return respostory;
        }

    }
}
