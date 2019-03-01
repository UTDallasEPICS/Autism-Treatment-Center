using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;

using Foundation;
using UIKit;

namespace ATS.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            //  This is information over what will be logged by aws services
            var loggingConfig = AWSConfigs.LoggingConfig;
            loggingConfig.LogMetrics = true;
            loggingConfig.LogResponses = ResponseLoggingOption.Always;
            loggingConfig.LogMetricsFormat = LogMetricsFormatOption.JSON;
            loggingConfig.LogTo = LoggingOptions.SystemDiagnostics;

            //  Sets the default region for amazon services, but can be ovveridded with credential
            //  instantiation
            AWSConfigs.AWSRegion = "us-east-1";

            //  This sets amazon services to correct for clockskew
            //  ClockKew is when client system clock and server clock times differ by 15 minutes
            AWSConfigs.CorrectForClockSkew = true;

            return base.FinishedLaunching(app, options);
        }
    }
}
