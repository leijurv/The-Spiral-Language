module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_6(float * var_0, float * var_1);
    __global__ void method_12(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __device__ float method_7(float * var_0, float var_1, long long int var_2);
    __device__ float method_8(float var_0, float var_1);
    __device__ void method_13(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5);
    
    __global__ void method_6(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        float var_10 = 0;
        float var_11 = method_7(var_0, var_10, var_9);
        FunPointer0 var_14 = method_8;
        float var_15 = cub::BlockReduce<float,128>().Reduce(var_11, var_14);
        char var_16 = (var_2 == 0);
        if (var_16) {
            char var_17 = (var_5 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_5 < 1);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // unprinted assert;
            } else {
            }
            var_1[var_5] = var_15;
        } else {
        }
    }
    __global__ void method_12(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_13(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __device__ float method_7(float * var_0, float var_1, long long int var_2) {
        char var_3 = (var_2 < 36);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = (var_1 + var_6);
            long long int var_8 = (var_2 + 128);
            return method_7(var_0, var_7, var_8);
        } else {
            return var_1;
        }
    }
    __device__ float method_8(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_13(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < 36);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float var_9 = var_2[var_5];
            float var_10 = var_3[var_5];
            float var_11 = (var_9 + var_0);
            var_4[var_5] = var_11;
            long long int var_12 = (var_5 + 128);
            method_13(var_0, var_1, var_2, var_3, var_4, var_12);
        } else {
        }
    }
}
"""

type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env2 =
    struct
    val mem_0: Env3
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union4 =
    | Union4Case0 of Tuple5
    | Union4Case1
and Tuple5 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env3 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env3) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env3), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_5((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_11((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref))): float32 =
    let (var_3: Union4) = (!var_2)
    match var_3 with
    | Union4Case0(var_4) ->
        var_4.mem_0
    | Union4Case1 ->
        let (var_6: float32) = method_9((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext))
        var_2 := (Union4Case0(Tuple5(var_6)))
        var_6
and method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: (Union0 ref)), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
    let (var_14: int64) = (var_11 - var_10)
    let (var_15: int64) = (var_13 - var_12)
    let (var_16: int64) = (var_14 * var_15)
    let (var_17: bool) = (var_10 < var_11)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_19: bool) = (var_12 < var_13)
    let (var_20: bool) = (var_19 = false)
    if var_20 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_21: bool) = (0L = var_7)
    let (var_22: bool) = (var_21 = false)
    if var_22 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_23: bool) = (var_6 = 0L)
    let (var_24: bool) = (var_23 = false)
    if var_24 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_5: (Union0 ref)))
    let (var_26: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_16))
    var_0.CopyToHost(var_26, var_25)
    var_0.Synchronize()
    let (var_27: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_28: string) = ""
    let (var_29: int64) = 0L
    method_15((var_27: System.Text.StringBuilder), (var_29: int64))
    let (var_30: System.Text.StringBuilder) = var_27.AppendLine("[|")
    method_16((var_27: System.Text.StringBuilder), (var_28: string), (var_26: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_31: int64) = 0L
    method_15((var_27: System.Text.StringBuilder), (var_31: int64))
    let (var_32: System.Text.StringBuilder) = var_27.AppendLine("|]")
    let (var_33: string) = var_27.ToString()
    let (var_34: string) = System.String.Format("{0}",var_33)
    System.Console.WriteLine(var_34)
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env3), (var_6: int64)): Env3 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64 var_3
    let (var_13: uint64) = (var_12 + var_11)
    let (var_14: bool) = (var_13 <= var_2)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_16: uint64) = (var_8 + var_9)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_18))))
    var_4.Push((Env2((Env3(var_19)), var_3)))
    (Env3(var_19))
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env3 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    var_3.Push((Env2((Env3(var_9)), var_2)))
    (Env3(var_9))
and method_9((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext)): float32 =
    let (var_2: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_0: (Union0 ref)))
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_1.CopyToHost(var_3, var_2)
    var_1.Synchronize()
    let (var_4: float32) = 0.000000f
    let (var_5: int64) = 0L
    method_10((var_3: (float32 [])), (var_4: float32), (var_5: int64))
and method_15((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_15((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_16((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: bool) = (var_7 >= var_7)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: int64) = (var_3 + var_4)
        let (var_15: int64) = 0L
        method_17((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_18((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_20((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_10((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 1L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = var_0.[int32 var_2]
        let (var_7: float32) = (var_1 + var_6)
        let (var_8: int64) = (var_2 + 1L)
        method_10((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_17((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_17((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_18((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
    let (var_7: bool) = (var_4 < var_5)
    if var_7 then
        let (var_8: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_9: bool) = (var_4 >= var_4)
        let (var_10: bool) = (var_9 = false)
        if var_10 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_11: float32) = var_1.[int32 var_2]
        let (var_12: string) = System.String.Format("{0}",var_11)
        let (var_13: System.Text.StringBuilder) = var_0.Append(var_12)
        let (var_14: string) = "; "
        let (var_15: int64) = (var_4 + 1L)
        method_19((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_20((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: bool) = (var_11 >= var_7)
        let (var_14: bool) = (var_13 = false)
        if var_14 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_15: int64) = (var_11 - var_7)
        let (var_16: int64) = (var_15 * var_5)
        let (var_17: int64) = (var_3 + var_16)
        let (var_18: int64) = (var_17 + var_4)
        let (var_19: int64) = 0L
        method_17((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_18((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_20((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_19((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
    let (var_8: bool) = (var_7 < var_5)
    if var_8 then
        let (var_9: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_10: bool) = (var_7 >= var_4)
        let (var_11: bool) = (var_10 = false)
        if var_11 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_12: int64) = (var_7 - var_4)
        let (var_13: int64) = (var_12 * var_3)
        let (var_14: int64) = (var_2 + var_13)
        let (var_15: float32) = var_1.[int32 var_14]
        let (var_16: string) = System.String.Format("{0}",var_15)
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_16)
        let (var_18: string) = "; "
        let (var_19: int64) = (var_7 + 1L)
        method_19((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
    else
        var_6
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_1.Synchronize()
let (var_2: string) = System.Environment.get_CurrentDirectory()
let (var_3: string) = System.IO.Path.Combine(var_2, "nvcc_router.bat")
let (var_4: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_4.set_RedirectStandardOutput(true)
var_4.set_RedirectStandardError(true)
var_4.set_UseShellExecute(false)
var_4.set_FileName(var_3)
let (var_5: System.Diagnostics.Process) = System.Diagnostics.Process()
var_5.set_StartInfo(var_4)
let (var_7: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_5.OutputDataReceived.Add(var_7)
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64")
let (var_10: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\include")
let (var_12: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "bin\\nvcc.exe")
let (var_13: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_14: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_15: bool) = System.IO.File.Exists(var_14)
if var_15 then
    System.IO.File.Delete(var_14)
else
    ()
System.IO.File.WriteAllText(var_14, var_0)
let (var_16: bool) = System.IO.File.Exists(var_3)
if var_16 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_17: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_18: System.IO.StreamWriter) = System.IO.StreamWriter(var_17)
var_18.WriteLine("SETLOCAL")
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\""|]
var_18.WriteLine(var_19)
let (var_20: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_9; "\""|]
var_18.WriteLine(var_20)
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:\\cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
var_18.WriteLine(var_21)
var_18.Dispose()
var_17.Dispose()
let (var_22: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_23: bool) = var_5.Start()
let (var_24: bool) = (var_23 = false)
if var_24 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_25: int32) = var_5.get_ExitCode()
let (var_26: bool) = (var_25 = 0)
let (var_27: bool) = (var_26 = false)
if var_27 then
    let (var_28: string) = System.String.Format("{0}",var_25)
    let (var_29: string) = String.concat ", " [|"NVCC failed compilation."; var_28|]
    let (var_30: string) = System.String.Format("[{0}]",var_29)
    (failwith var_30)
else
    ()
let (var_31: System.TimeSpan) = var_22.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_31
let (var_32: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_33: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_34: string) = System.String.Format("{0}",var_33)
System.Console.WriteLine(var_34)
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.700000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_51: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_50)
let (var_52: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_51.SetStream(var_52)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaBlas.CudaBlasHandle) = var_55.get_CublasHandle()
let (var_57: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_55.set_Stream(var_57)
let (var_58: int64) = 144L
let (var_59: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_62: ManagedCuda.BasicTypes.SizeT) = var_61.Pointer
let (var_63: uint64) = uint64 var_62
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_63)
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_64)
let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(36L)
var_51.GenerateNormal32(var_65, var_66, 1.000000f, 1.000000f)
let (var_67: int64) = 144L
let (var_68: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_67: int64))
let (var_69: (Union0 ref)) = var_68.mem_0
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_71: ManagedCuda.BasicTypes.SizeT) = var_70.Pointer
let (var_72: uint64) = uint64 var_71
let (var_73: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_72)
let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_73)
let (var_75: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_76: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(144L)
var_1.ClearMemoryAsync(var_74, 0uy, var_76, var_75)
let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_78: ManagedCuda.BasicTypes.SizeT) = var_77.Pointer
let (var_79: uint64) = uint64 var_78
let (var_80: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_79)
let (var_81: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_80)
let (var_82: int64) = 4L
let (var_83: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_82: int64))
let (var_84: (Union0 ref)) = var_83.mem_0
let (var_85: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_84: (Union0 ref)))
let (var_86: ManagedCuda.BasicTypes.SizeT) = var_85.Pointer
let (var_87: uint64) = uint64 var_86
let (var_88: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_87)
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_88)
// Cuda join point
// method_6((var_81: ManagedCuda.BasicTypes.CUdeviceptr), (var_89: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_91: (System.Object [])) = [|var_81; var_89|]: (System.Object [])
let (var_92: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_6", var_32, var_1)
let (var_93: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_92.set_GridDimensions(var_93)
let (var_94: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_92.set_BlockDimensions(var_94)
let (var_95: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_92.RunAsync(var_95, var_91)
let (var_97: (Union4 ref)) = (ref Union4Case1)
let (var_98: (float32 ref)) = (ref 0.000000f)
var_98 := 1.000000f
let (var_99: float32) = method_11((var_84: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_97: (Union4 ref)))
let (var_100: float32) = (!var_98)
let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_102: ManagedCuda.BasicTypes.SizeT) = var_101.Pointer
let (var_103: uint64) = uint64 var_102
let (var_104: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_103)
let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_104)
let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_107: ManagedCuda.BasicTypes.SizeT) = var_106.Pointer
let (var_108: uint64) = uint64 var_107
let (var_109: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_108)
let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_109)
let (var_111: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_112: ManagedCuda.BasicTypes.SizeT) = var_111.Pointer
let (var_113: uint64) = uint64 var_112
let (var_114: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_113)
let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_114)
// Cuda join point
// method_12((var_100: float32), (var_99: float32), (var_105: ManagedCuda.BasicTypes.CUdeviceptr), (var_110: ManagedCuda.BasicTypes.CUdeviceptr), (var_115: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_117: (System.Object [])) = [|var_100; var_99; var_105; var_110; var_115|]: (System.Object [])
let (var_118: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_12", var_32, var_1)
let (var_119: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_118.set_GridDimensions(var_119)
let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_118.set_BlockDimensions(var_120)
let (var_121: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_118.RunAsync(var_121, var_117)
let (var_122: int64) = 0L
let (var_123: int64) = 0L
let (var_124: int64) = 6L
let (var_125: int64) = 1L
let (var_126: int64) = 0L
let (var_127: int64) = 6L
let (var_128: int64) = 0L
let (var_129: int64) = 6L
method_14((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_69: (Union0 ref)), (var_122: int64), (var_123: int64), (var_124: int64), (var_125: int64), (var_126: int64), (var_127: int64), (var_128: int64), (var_129: int64))
var_84 := Union0Case1
var_69 := Union0Case1
var_60 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_130)
var_43 := Union0Case1
var_1.Dispose()

