namespace Stonksy.Core.Utils

module AsyncOption =
    
    let bind (f : 'a -> Async<Option<'b>>) (a : Async<Option<'a>>)  : Async<Option<'b>> = async {
        match! a with
        | Some value ->
            let next : Async<Option<'b>> = f value
            return! next
        | None -> return None
    }
    
    let map (f : 'a -> Async<'b>) (a : Async<Option<'a>>)  : Async<Option<'b>> = async {
        match! a with
        | Some value ->
            let! next = f value
            return Some(next)
        | None -> return None
    }
    
    let compose (f : 'a -> Async<Option<'b>>) (g : 'b -> Async<Option<'c>>) : 'a -> Async<Option<'c>> =
        fun x -> bind g (f x)    