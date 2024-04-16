using MakeMeUpzz.Model;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class MakeUpHandler
    {
        private MakeupRepository repository;

        public MakeUpHandler()
        {
            this.repository = new MakeupRepository();
        }

        public List<Makeup> GetMakeups()
        {
            return repository.GetMakeups();
        }
    }
}