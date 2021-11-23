using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsLike_ProjetoFinal.Data
{
    public class LetsLikeContest : DbContext
    {

        public LetsLikeContest(DbContextOptions<LetsLikeContest> options : base(options)
        {

        } 
    }
}
