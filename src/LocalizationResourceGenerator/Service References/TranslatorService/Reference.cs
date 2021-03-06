﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TranslatorService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.3.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://api.microsofttranslator.com/v1/soap.svc", ConfigurationName="TranslatorService.LanguageService")]
    public interface LanguageService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguages", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguagesRespon" +
            "se")]
        System.Threading.Tasks.Task<string[]> GetLanguagesAsync(string appId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNames", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/GetLanguageNamesRe" +
            "sponse")]
        System.Threading.Tasks.Task<string[]> GetLanguageNamesAsync(string appId, string locale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Detect", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/DetectResponse")]
        System.Threading.Tasks.Task<string> DetectAsync(string appId, string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/Translate", ReplyAction="http://api.microsofttranslator.com/v1/soap.svc/LanguageService/TranslateResponse")]
        System.Threading.Tasks.Task<string> TranslateAsync(string appId, string text, string from, string to);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.3.0.0")]
    public interface LanguageServiceChannel : TranslatorService.LanguageService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "0.3.0.0")]
    public partial class LanguageServiceClient : System.ServiceModel.ClientBase<TranslatorService.LanguageService>, TranslatorService.LanguageService
    {
        
    /// <summary>
    /// Implement this partial method to configure the service endpoint.
    /// </summary>
    /// <param name="serviceEndpoint">The endpoint to configure</param>
    /// <param name="clientCredentials">The client credentials</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), LanguageServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LanguageServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LanguageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string[]> GetLanguagesAsync(string appId)
        {
            return base.Channel.GetLanguagesAsync(appId);
        }
        
        public System.Threading.Tasks.Task<string[]> GetLanguageNamesAsync(string appId, string locale)
        {
            return base.Channel.GetLanguageNamesAsync(appId, locale);
        }
        
        public System.Threading.Tasks.Task<string> DetectAsync(string appId, string text)
        {
            return base.Channel.DetectAsync(appId, text);
        }
        
        public System.Threading.Tasks.Task<string> TranslateAsync(string appId, string text, string from, string to)
        {
            return base.Channel.TranslateAsync(appId, text, from, to);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService1))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService))
            {
                return new System.ServiceModel.EndpointAddress("http://api.microsofttranslator.com/V1/soap.svc");
            }
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_LanguageService1))
            {
                return new System.ServiceModel.EndpointAddress("http://api.microsofttranslator.com/V1/soap.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_LanguageService,
            
            BasicHttpBinding_LanguageService1,
        }
    }
}
