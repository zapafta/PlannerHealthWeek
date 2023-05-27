using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlannerHealthWeek.Data.Enum;
using PlannerHealthWeek.Data.Model;
using PlannerHealthWeek.Data.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlannerHealthWeek.Data.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }


        public List <ElementOfScheduler> GetByDate(DateTime Start, DateTime End,string UserLogged)
        {
            List<ElementOfScheduler> toReturn = new();


                        var user = context.Users.FirstOrDefault(e => e.Email == UserLogged);

            int PlanoAlimentacao = context.PlanoAlimentacao.FirstOrDefault(e => e.UserId == user.Id).IdPlanoAlimentacao;






            var GuidsTemp = context.ItemPlanoAlimentacao
                .Include(e => e.Receita).ThenInclude(e => e.ListReceitaItem)
                .Where(e => e.PlanoAlimentacao.IdPlanoAlimentacao == PlanoAlimentacao)
                .Select(e => new ElementOfScheduler
                {
                    MealType = e.MealType,
                    DateOfDay = e.Date,
                    DayOfWeek = e.Date.DayOfWeek,
                    NomeReceita = e.Receita.Description,
                    ReceitaKcal = 49.ToString(),
                    NutriScoreDay = "A",
                    NutriScoreReceita = "B"
                }

                ).ToList();
                
           toReturn.AddRange(GuidsTemp);




            return toReturn;
        }




        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
