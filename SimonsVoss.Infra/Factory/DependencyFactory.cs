using Microsoft.Extensions.DependencyInjection;
using System;

namespace SimonsVoss.Infra.Factory
{
    public class DependencyFactory
    {
        private static readonly Lazy<DependencyFactory> lazy = new Lazy<DependencyFactory>(() => new DependencyFactory());

        public static DependencyFactory Instance { get { return lazy.Value; } }

        private IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;

        private IServiceCollection Container { get { return _serviceCollection; } }

        private DependencyFactory()
        {
            _serviceCollection = new ServiceCollection();
        }

        public void AddSingleton<T>(T instance) => Container.AddSingleton(typeof(T), instance);

        public void AddScoped<T>(Type type) => Container.AddScoped(typeof(T), type);

        public void AddTransient<T>(Type type) => Container.AddTransient(typeof(T), type);

        public void Init() => _serviceProvider = Container.BuildServiceProvider();

        public T Resolve<T>() => _serviceProvider.GetService<T>();
        
    }
}
