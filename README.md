# panosen-wxmini-api
Panosen Wexin Mini Program Server Api

```
    <PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="5.0.0" />
```

```
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddSingleton<JscodeToSession>();
            services.AddSingleton(new WechatOptions
            {
                AppId = "",
                AppSecret = ""
            });

            var serviceProvider = services.BuildServiceProvider();

            var jscodeToSession = serviceProvider.GetRequiredService<JscodeToSession>();
```
