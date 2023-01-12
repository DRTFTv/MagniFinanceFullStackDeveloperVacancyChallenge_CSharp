using Backend.Models.Courses;
using Backend.Models.Students;
using Backend.Models.Students.Students;
using Backend.Models.Subjects;
using Backend.Models.Teachers;

namespace Backend
{
    public class Startup
    {
        public IConfiguration _configuration{ get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ///
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ITeachersRepository, TeachersRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<ISubjectsRepository, SubjectsRepository>();
        }

        public void Configue(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
