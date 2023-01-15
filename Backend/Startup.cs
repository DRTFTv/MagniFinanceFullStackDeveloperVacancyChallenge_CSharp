using Backend.Hubs;
using Backend.Models.Courses;
using Backend.Models.Grades;
using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.Models.Subjects;
using Backend.Models.Teachers;

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
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            ///
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ITeachersRepository, TeachersRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
            services.AddScoped<IGradesRepository, GradeRepository>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors("EnableCORS");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<StreamingHub>("/StreamingHub");
            });

            app.Run();
        }
    }
}
