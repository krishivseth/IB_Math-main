﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IB_Math.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IB_MathEntities : DbContext
    {
        public IB_MathEntities()
            : base("name=IB_MathEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CourseQueAn> CourseQueAns { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<DaigtestAn> DaigtestAns { get; set; }
        public virtual DbSet<DiagnosticTest> DiagnosticTests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersCours> UsersCourses { get; set; }
        public virtual DbSet<UsersDiagnostictest> UsersDiagnostictests { get; set; }
    
        public virtual ObjectResult<sp_GetStudentScore_Result> sp_GetStudentScore()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetStudentScore_Result>("sp_GetStudentScore");
        }
    
        public virtual ObjectResult<sp_GetStudentwiseScore_Result> sp_GetStudentwiseScore(Nullable<int> inp_UserId)
        {
            var inp_UserIdParameter = inp_UserId.HasValue ?
                new ObjectParameter("inp_UserId", inp_UserId) :
                new ObjectParameter("inp_UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetStudentwiseScore_Result>("sp_GetStudentwiseScore", inp_UserIdParameter);
        }
    }
}
