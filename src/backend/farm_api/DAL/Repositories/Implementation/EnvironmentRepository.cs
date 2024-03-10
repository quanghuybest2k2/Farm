using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DAL.Context;
using Environment = Core.Entities.Environment;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.GenericRepository;


namespace DAL.Repositories.Implementation
{
    public class EnvironmentRepository : GenericRepository<Environment>, IEnvironmentRepository
    {
       public EnvironmentRepository(FarmContext context):base(context) { }


    }
}
