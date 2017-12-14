#if SECURITY_DEP
#if MONO_SECURITY_ALIAS
extern alias MonoSecurity;
#endif

#if MONO_SECURITY_ALIAS
using MonoSecurity::Mono.Security.Interface;
#else
using Mono.Security.Interface;
#endif

namespace Mono.Unity
{
	internal static class Debug
	{
		public static void CheckAndThrow(UnityTls.unitytls_errorstate errorState, string context)
		{
			if (errorState.code != UnityTls.unitytls_error_code.UNITYTLS_SUCCESS) {
				string message = string.Format("{0} - error code {1}", context, errorState.code);
				throw new TlsException(AlertDescription.InternalError, message);
			}
		}
	}
}
#endif