// Build the callChain based on the provided policies and faults.
ISyncPolicy<T>? callChain = null;
if(CallOptions.Policies != null)
	callChain = CallOptions.Policies;
if (TypedRoute.Faults != null)
	callChain = callChain == null ? TypedRoute.Faults : Policy.Wrap(callChain, TypedRoute.Faults);


var value = callChain != null ? callChain.Execute(() => TypedRoute.Value()) : TypedRoute.Value();