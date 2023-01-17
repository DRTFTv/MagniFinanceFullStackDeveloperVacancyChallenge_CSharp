using Backend.Hubs;
using Backend.Models;
using Backend.Models.Courses;
using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.Models.Students_Subjects;
using Backend.Models.Subjects;
using Backend.Models.Teachers;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials());
            });

            ///
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudents_SubjectsRepository, Students_SubjectsRepository>();
            services.AddScoped<ITeachersRepository, TeachersRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
            services.AddScoped<IGradesRepository, GradeRepository>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<StreamingHub>("/StreamingHub");
            });

            app.Run();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<UniversityDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
