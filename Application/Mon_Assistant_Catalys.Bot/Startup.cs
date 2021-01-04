using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.BotFramework;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Integration;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mon_Assistant_Catalys.Bot.Bots;

namespace Mon_Assistant_Catalys.Bot
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            ContentRootPath = env.ContentRootPath;   
        }

        public string ContentRootPath { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set up the service configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            services.AddSingleton(configuration);

            services.AddBot<CatalysBot>(options =>
            {
                var conversationState = new ConversationState(new MemoryStorage());
                options.State.Add(conversationState);

                options.CredentialProvider = new ConfigurationCredentialProvider(configuration);
            });

            services.AddSingleton(serviceProvider =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<BotFrameworkOptions>>().Value;
                var conversationState = options.State.OfType<ConversationState>().FirstOrDefault();

                var accessors = new BotAccessor(conversationState)
                {
                    DialogStateAccessor = conversationState.CreateProperty<DialogState>(BotAccessor.DialogStateAccessorName),
                    CatalysBotStateStateAccessor = conversationState.CreateProperty<CatalysBotState>(BotAccessor.CatalysBotStateAccessorName)
                };

                return accessors;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseBotFramework();
        }
    }
}
