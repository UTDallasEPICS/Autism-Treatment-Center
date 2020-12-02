package crc64e6bbec0cebca6418;


public class ActivityBase
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("GalaSoft.MvvmLight.Views.ActivityBase, GalaSoft.MvvmLight.Platform", ActivityBase.class, __md_methods);
	}


	public ActivityBase ()
	{
		super ();
		if (getClass () == ActivityBase.class)
			mono.android.TypeManager.Activate ("GalaSoft.MvvmLight.Views.ActivityBase, GalaSoft.MvvmLight.Platform", "", this, new java.lang.Object[] {  });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
