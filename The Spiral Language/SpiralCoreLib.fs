﻿module Spiral.CoreLib

let module_ = Types.module_
let core =
    (
    "Core",[],"The Core module.",
    """
inl type_lit_lift x = !TypeLitCreate(x)

inl error_type x = !ErrorType(x)
inl print_static x = !PrintStatic(x)
inl dyn x = !Dynamize(x)
inl (\/) a b = !TypeUnion(a,b)
inl (=>) a b = !TermFunctionTypeCreate(a,b)
inl split x = !TypeSplit(x)
inl box a b = !TypeBox(a,b)
inl stack x = !LayoutToStack(x)
inl packed_stack x = !LayoutToPackedStack(x)
inl heap x = !LayoutToHeap(x)
inl heapm x = !LayoutToHeapMutable(x)
inl indiv x = !LayoutToNone(x)

inl bool = type(true)

inl int64 = type(0i64)
inl int32 = type(0i32)
inl int16 = type(0i16)
inl int8 = type(0i8)

inl uint64 = type(0u64)
inl uint32 = type(0u32)
inl uint16 = type(0u16)
inl uint8 = type(0u8)

inl float64 = type(0f64)
inl float32 = type(0f32)

inl string = type("")
inl char = type(' ')
inl unit = type(())

inl type_lit_cast x = !TypeLitCast(x)
inl type_lit_is x = !TypeLitIs(x)
inl term_cast to from = !TermCast(to,from)
inl unsafe_convert to from = !UnsafeConvert(to,from) 
inl negate x = !Neg(x)
inl ignore x = ()
inl id x = x
inl const x _ = x
inl ref x = !ReferenceCreate(x)

inl array_create typ size = !ArrayCreate(size,typ)
inl array_length ar = !ArrayLength(ar)
inl array_is x = !ArrayIs(x)
inl array t = type (Array.create t 1)

inl (+) a b = !Add(a,b)
inl (-) a b = !Sub(a,b)
inl (*) a b = !Mult(a,b)
inl (/) a b = !Div(a,b)
inl (%) a b = !Mod(a,b)

inl (|>) a b = b a
inl (<|) a b = a b
inl (>>) a b x = b (a x)
inl (<<) a b x = a (b x)

inl (<=) a b = !LTE(a,b)
inl (<) a b = !LT(a,b)
inl (=) a b = !EQ(a,b)
inl (<>) a b = !NEQ(a,b)
inl (>) a b = !GT(a,b)
inl (>=) a b = !GTE(a,b)

inl (&&&) a b = !BitwiseAnd(a,b)
inl (|||) a b = !BitwiseOr(a,b)
inl (^^^) a b = !BitwiseXor(a,b)

inl (::) a b = !ListCons(a,b)
inl (<<<) a b = !ShiftLeft(a,b)
inl (>>>) a b = !ShiftRight(a,b)
inl Tuple = {
    length = inl x -> !ListLength(x)
    index = inl v i -> !ListIndex(v,i)
    }

inl fst x :: _ = x
inl snd _ :: x :: _ = x

inl not x = x = false
inl string_length x = !StringLength(x)
inl string_format a b = !StringFormat(a,b)
inl lit_is x = !LitIs(x)
inl box_is x = !BoxIs(x)
inl caseable_is x = !CaseableIs(x)
inl caseable_boxed_is x = !CaseableBoxedIs(x)
inl failwith typ msg = !FailWith(typ,msg)
inl assert c msg = 
    // Note: testing `lit_is c` needs to be done before testing for `c = false` otherwise the CSE rewrite will mess up the program.
    // Do not add an argument to raise.
    inl raise = 
        if lit_is c then error_type
        else failwith unit
    
    if c = false then raise msg
    
inl max a b = if a > b then a else b
inl min a b = if a > b then b else a
inl eq_type a b = !EqType(a,b)
inl module_values x = !ModuleValues(x)
inl module_map f a = !ModuleMap(f,a)
inl module_foldl f s a = !ModuleFoldL(f,s,a)
inl module_has_member m x = !ModuleHasMember(m,x)
inl (:>) a b = !UnsafeUpcastTo(b,a)
inl (:?>) a b = !UnsafeDowncastTo(b,a)

inl prim_eq = (=)
// Structural polymorphic equality for every type in the language (apart from functions).
inl (=) a b =
    inl rec (=) a b =
        inl body = function
            | .(a), .(b) -> a = b
            | a :: as', b :: bs -> a = b && as' = bs
            | {} & a, {} & b -> module_values a = module_values b
            | (), () -> true
            | a, b when eq_type a b -> prim_eq a b // This repeat eq_type check is because unboxed union types might lead to variables of different types to be compared.
            | _ -> false
        // TODO: If I put in a hack for doing fast equality comparison on boxed union types remember 
        // to also allow comparison of type level function.
        if caseable_boxed_is a && caseable_boxed_is b then join (body (a, b) : bool)
        else body (a, b)
    if eq_type a b then a = b
    else error_type ("Trying to compare variables of two different types. Got:",a,b)

inl sizeof x = !SizeOf(x)

inl cuda x = !CudaTypeCreate(x)
inl fs x = !DotNetTypeCreate(x)

inl log x = !Log(x)
inl exp x = !Exp(x)
inl tanh x = !Tanh(x)

{type_lit_lift error_type print_static dyn (\/) (=>) cuda fs log exp tanh array_create array_length array_is array
 split box stack packed_stack heap heapm indiv bool int64 int32 int16 int8 uint64 uint32 uint16 uint8 float64 float32
 string char unit type_lit_cast type_lit_is term_cast unsafe_convert negate ignore id const ref (+) (-) (*) (/) (%)
 (|>) (<|) (>>) (<<) (<=) (<) (=) (<>) (>) (>=) (&&&) (|||) (^^^) (::) (<<<) (>>>) Tuple fst snd not
 string_length lit_is box_is failwith assert max min eq_type module_values caseable_is (:>)
 (:?>) (=) module_map module_foldl module_has_member sizeof string_format} |> stack
    """) |> module_
