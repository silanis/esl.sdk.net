namespace Silanis.ESL.SDK.Services
{
	/// <summary>
	/// This class is used for registering to the e-SL notification system.
	/// </summary>
	public class EventNotificationService
	{
        private readonly EventNotificationApiClient _apiClient;
        
		internal EventNotificationService(EventNotificationApiClient apiClient)
		{
            _apiClient = apiClient;
		}

		/// <summary>
		/// Registers to receive notifications sent by e-SL that are described by the config parameter passed to this method.
		/// </summary>
		/// <param name="config">Describes the event notification of interest.</param>
		public void Register(EventNotificationConfig config)
		{
            _apiClient.Register( new EventNotificationConfigConverter(config).ToAPICallback() );
		}

        /// <summary>
        /// Registers to receive notifications sent by e-SL that are described by the config parameter passed to this method.
        /// </summary>
        /// <param name="origin">The origin of the package.</param>
        /// <param name="config">Describes the event notification of interest.</param>
        public void Register(string origin, EventNotificationConfig config)
        {
            _apiClient.Register( origin, new EventNotificationConfigConverter(config).ToAPICallback() );
        }

		/// <summary>
		/// Registers to receive notifications sent by e-SL.
		/// <p>The builder parameter of this method is convenient to use when you want to easily add more notification events.</p>
		/// </summary>
		/// <param name="builder">The event notification config builder.</param>
		public void Register(EventNotificationConfigBuilder builder)
		{
			Register(builder.build());
		}

        /// <summary>
        /// Registers to receive notifications sent by e-SL.
        /// <p>The builder parameter of this method is convenient to use when you want to easily add more notification events.</p>
        /// </summary>
        /// <param name="origin">The origin of the package.</param>
        /// <param name="builder">The event notification config builder.</param>
        public void Register(string origin, EventNotificationConfigBuilder builder)
        {
            Register(origin, builder.build());
        }

		/// <summary>
		/// Gets the registered event notifications.
		/// </summary>
		/// <returns>Description of registered event notifications.</returns>
		public EventNotificationConfig GetEventNotificationConfig()
		{
            var apiResponse = _apiClient.GetEventNotificationConfig();
            return new EventNotificationConfigConverter(apiResponse).ToSDKEventNotificationConfig();
		}

        /// <summary>
        /// Gets the registered event notifications.
        /// </summary>
        /// <returns>Description of registered event notifications.</returns>
        public EventNotificationConfig GetEventNotificationConfig(string origin)
        {
            var apiResponse = _apiClient.GetEventNotificationConfig(origin);
            return new EventNotificationConfigConverter(apiResponse).ToSDKEventNotificationConfig();
        }
	}
}
