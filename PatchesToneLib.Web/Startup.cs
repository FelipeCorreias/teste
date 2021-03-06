using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatchesToneLib.Application.Interfaces;
using PatchesToneLib.Application.Patches.Commands.ApprovePatch;
using PatchesToneLib.Application.Patches.Commands.CreatePatch;
using PatchesToneLib.Application.Patches.Commands.DeletePatch;
using PatchesToneLib.Application.Patches.Commands.UpdatePatch;
using PatchesToneLib.Application.Patches.Queries.GetPatchDetail;
using PatchesToneLib.Application.Patches.Queries.GetPatchesList;
using PatchesToneLib.Application.Patches.Queries.GetPatchesListByModel;
using PatchesToneLib.Application.Patches.Queries.GetPatchesToApproveList;
using PatchesToneLib.Application.Patches.Queries.GetPatchFile;
using PatchesToneLib.Common.Files;
using PatchesToneLib.Persistance;
using System;

namespace PatchesToneLib.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //*PATCH*//
            //*QUERIES*//
            services.AddScoped<IGetPatchesListQuery, GetPatchesListQuery>();
            services.AddScoped<IGetPatchDetailQuery, GetPatchDetailQuery>();
            services.AddScoped<IGetPatchFileQuery, GetPatchFileQuery>();
            services.AddScoped<IGetPatchesListByModelQuery, GetPatchesListByModelQuery>();
            services.AddScoped<IGetPatchesListToApproveQuery, GetPatchesListToApproveQuery>();
            //*COMMANDS*//
            services.AddScoped<ICreatePatchCommand, CreatePatchCommand>();
            services.AddScoped<IUpdatePatchCommand, UpdatePatchCommand>();
            services.AddScoped<IDeletePatchCommand, DeletePatchCommand>();
            services.AddScoped<IApprovePatchCommand, ApprovePatchCommand>();


            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IDatabaseService, DatabaseService>();

            services.AddMvc();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.Options.StartupTimeout = new TimeSpan(0, 0, 80);
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
