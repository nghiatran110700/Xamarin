package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("TestApi.Droid.MainApplication, TestApi.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc648b1e60bbd802b569.MainApplication.class, crc648b1e60bbd802b569.MainApplication.__md_methods);
		
	}
}
