module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_6(float * var_0, float * var_1);
    __global__ void method_8(float * var_0, float * var_1, float * var_2);
    __global__ void method_16(float var_0, float var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_18(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ void method_7(float * var_0, float * var_1, long long int var_2);
    __device__ float method_9(float * var_0, float * var_1, float var_2, long long int var_3);
    __device__ float method_10(float var_0, float var_1);
    __device__ void method_17(float var_0, float var_1, float * var_2, float * var_3, float * var_4, float * var_5, long long int var_6);
    __device__ void method_19(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, long long int var_5);
    
    __global__ void method_6(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_7(var_0, var_1, var_9);
    }
    __global__ void method_8(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        float var_12 = method_9(var_0, var_1, var_11, var_10);
        FunPointer0 var_15 = method_10;
        float var_16 = cub::BlockReduce<float,128>().Reduce(var_12, var_15);
        char var_17 = (var_3 == 0);
        if (var_17) {
            char var_18 = (var_6 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_6 < 1);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // unprinted assert;
            } else {
            }
            var_2[var_6] = var_16;
        } else {
        }
    }
    __global__ void method_16(float var_0, float var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = (var_9 * 128);
        long long int var_13 = (var_12 + var_6);
        method_17(var_0, var_1, var_2, var_3, var_4, var_5, var_13);
    }
    __global__ void method_18(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_19(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __device__ void method_7(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 8);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = (-var_6);
            float var_8 = exp(var_7);
            float var_9 = (1 + var_8);
            float var_10 = (1 / var_9);
            var_1[var_2] = var_10;
            long long int var_11 = (var_2 + 128);
            method_7(var_0, var_1, var_11);
        } else {
        }
    }
    __device__ float method_9(float * var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 8);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float var_7 = var_0[var_3];
            float var_8 = var_1[var_3];
            float var_9 = (var_8 - var_7);
            float var_10 = (var_9 * var_9);
            float var_11 = (var_2 + var_10);
            long long int var_12 = (var_3 + 128);
            return method_9(var_0, var_1, var_11, var_12);
        } else {
            return var_2;
        }
    }
    __device__ float method_10(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_17(float var_0, float var_1, float * var_2, float * var_3, float * var_4, float * var_5, long long int var_6) {
        char var_7 = (var_6 < 8);
        if (var_7) {
            char var_8 = (var_6 >= 0);
            char var_9 = (var_8 == 0);
            if (var_9) {
                // unprinted assert;
            } else {
            }
            if (var_9) {
                // unprinted assert;
            } else {
            }
            float var_10 = var_2[var_6];
            float var_11 = var_3[var_6];
            float var_12 = var_4[var_6];
            float var_13 = (var_11 - var_12);
            float var_14 = (2 * var_13);
            float var_15 = (var_0 * var_14);
            float var_16 = (var_10 + var_15);
            var_5[var_6] = var_16;
            long long int var_17 = (var_6 + 128);
            method_17(var_0, var_1, var_2, var_3, var_4, var_5, var_17);
        } else {
        }
    }
    __device__ void method_19(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < 8);
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
            float var_9 = var_0[var_5];
            float var_10 = var_1[var_5];
            float var_11 = var_2[var_5];
            float var_12 = var_3[var_5];
            float var_13 = (1 - var_12);
            float var_14 = (var_12 * var_13);
            float var_15 = (var_11 * var_14);
            float var_16 = (var_9 + var_15);
            var_4[var_5] = var_16;
            long long int var_17 = (var_5 + 128);
            method_19(var_0, var_1, var_2, var_3, var_4, var_17);
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
and method_15((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref)), (var_3: (Union4 ref))): float32 =
    let (var_4: Union4) = (!var_3)
    match var_4 with
    | Union4Case0(var_5) ->
        var_5.mem_0
    | Union4Case1 ->
        let (var_7: float32) = method_13((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref)))
        var_3 := (Union4Case0(Tuple5(var_7)))
        var_7
and method_14((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref))): float32 =
    let (var_3: Union4) = (!var_2)
    match var_3 with
    | Union4Case0(var_4) ->
        var_4.mem_0
    | Union4Case1 ->
        let (var_6: float32) = method_11((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext))
        var_2 := (Union4Case0(Tuple5(var_6)))
        var_6
and method_20((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: (Union0 ref)), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
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
    method_21((var_27: System.Text.StringBuilder), (var_29: int64))
    let (var_30: System.Text.StringBuilder) = var_27.AppendLine("[|")
    method_22((var_27: System.Text.StringBuilder), (var_28: string), (var_26: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_31: int64) = 0L
    method_21((var_27: System.Text.StringBuilder), (var_31: int64))
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
and method_13((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref))): float32 =
    let (var_3: float32) = method_14((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union4 ref)))
    (var_3 / 2.000000f)
and method_11((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext)): float32 =
    let (var_2: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_0: (Union0 ref)))
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_1.CopyToHost(var_3, var_2)
    var_1.Synchronize()
    let (var_4: float32) = 0.000000f
    let (var_5: int64) = 0L
    method_12((var_3: (float32 [])), (var_4: float32), (var_5: int64))
and method_21((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_21((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_22((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
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
        method_23((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_24((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_12((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
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
        method_12((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_23((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_23((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_24((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
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
        method_25((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
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
        method_23((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_24((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_25((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
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
        method_25((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
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
let (var_58: int64) = 48L
let (var_59: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_62: ManagedCuda.BasicTypes.SizeT) = var_61.Pointer
let (var_63: uint64) = uint64 var_62
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_63)
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_64)
let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(12L)
var_51.GenerateNormal32(var_65, var_66, 0.000000f, 1.000000f)
let (var_67: int64) = 96L
let (var_68: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_67: int64))
let (var_69: (Union0 ref)) = var_68.mem_0
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_71: ManagedCuda.BasicTypes.SizeT) = var_70.Pointer
let (var_72: uint64) = uint64 var_71
let (var_73: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_72)
let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_73)
let (var_75: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(24L)
var_51.GenerateNormal32(var_74, var_75, 0.000000f, 1.000000f)
let (var_76: int64) = 96L
let (var_77: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_76: int64))
let (var_78: (Union0 ref)) = var_77.mem_0
let (var_79: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_78: (Union0 ref)))
let (var_80: ManagedCuda.BasicTypes.SizeT) = var_79.Pointer
let (var_81: uint64) = uint64 var_80
let (var_82: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_81)
let (var_83: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_82)
let (var_84: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_85: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(96L)
var_1.ClearMemoryAsync(var_83, 0uy, var_85, var_84)
let (var_86: int64) = 32L
let (var_87: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_86: int64))
let (var_88: (Union0 ref)) = var_87.mem_0
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_88: (Union0 ref)))
let (var_90: ManagedCuda.BasicTypes.SizeT) = var_89.Pointer
let (var_91: uint64) = uint64 var_90
let (var_92: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_91)
let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_92)
let (var_94: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_95: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32L)
var_1.ClearMemoryAsync(var_93, 0uy, var_95, var_94)
let (var_96: int64) = 32L
let (var_97: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_96: int64))
let (var_98: (Union0 ref)) = var_97.mem_0
let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_100: ManagedCuda.BasicTypes.SizeT) = var_99.Pointer
let (var_101: uint64) = uint64 var_100
let (var_102: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_101)
let (var_103: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_102)
let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_69: (Union0 ref)))
let (var_105: ManagedCuda.BasicTypes.SizeT) = var_104.Pointer
let (var_106: uint64) = uint64 var_105
let (var_107: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_106)
let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_107)
let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_98: (Union0 ref)))
let (var_110: ManagedCuda.BasicTypes.SizeT) = var_109.Pointer
let (var_111: uint64) = uint64 var_110
let (var_112: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_111)
let (var_113: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_112)
let (var_114: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_115: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_116: (float32 ref)) = (ref 1.000000f)
let (var_117: (float32 ref)) = (ref 0.000000f)
let (var_118: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_56, var_114, var_115, 2, 4, 6, var_116, var_103, 2, var_108, 6, var_117, var_113, 2)
if var_118 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_118)
let (var_119: int64) = 32L
let (var_120: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_119: int64))
let (var_121: (Union0 ref)) = var_120.mem_0
let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_121: (Union0 ref)))
let (var_123: ManagedCuda.BasicTypes.SizeT) = var_122.Pointer
let (var_124: uint64) = uint64 var_123
let (var_125: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_124)
let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_125)
let (var_127: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_128: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32L)
var_1.ClearMemoryAsync(var_126, 0uy, var_128, var_127)
let (var_133: int64) = 32L
let (var_134: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_133: int64))
let (var_135: (Union0 ref)) = var_134.mem_0
let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_98: (Union0 ref)))
let (var_137: ManagedCuda.BasicTypes.SizeT) = var_136.Pointer
let (var_138: uint64) = uint64 var_137
let (var_139: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_138)
let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_139)
let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_135: (Union0 ref)))
let (var_142: ManagedCuda.BasicTypes.SizeT) = var_141.Pointer
let (var_143: uint64) = uint64 var_142
let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_143)
let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_144)
// Cuda join point
// method_6((var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_145: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_147: (System.Object [])) = [|var_140; var_145|]: (System.Object [])
let (var_148: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_6", var_32, var_1)
let (var_149: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_148.set_GridDimensions(var_149)
let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_148.set_BlockDimensions(var_150)
let (var_151: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_148.RunAsync(var_151, var_147)
let (var_152: int64) = 32L
let (var_153: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_152: int64))
let (var_154: (Union0 ref)) = var_153.mem_0
let (var_155: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_154: (Union0 ref)))
let (var_156: ManagedCuda.BasicTypes.SizeT) = var_155.Pointer
let (var_157: uint64) = uint64 var_156
let (var_158: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_157)
let (var_159: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_158)
let (var_160: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_161: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32L)
var_1.ClearMemoryAsync(var_159, 0uy, var_161, var_160)
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_135: (Union0 ref)))
let (var_163: ManagedCuda.BasicTypes.SizeT) = var_162.Pointer
let (var_164: uint64) = uint64 var_163
let (var_165: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_164)
let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_165)
let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_88: (Union0 ref)))
let (var_168: ManagedCuda.BasicTypes.SizeT) = var_167.Pointer
let (var_169: uint64) = uint64 var_168
let (var_170: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_169)
let (var_171: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_170)
let (var_174: int64) = 4L
let (var_175: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_174: int64))
let (var_176: (Union0 ref)) = var_175.mem_0
let (var_177: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_176: (Union0 ref)))
let (var_178: ManagedCuda.BasicTypes.SizeT) = var_177.Pointer
let (var_179: uint64) = uint64 var_178
let (var_180: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_179)
let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_180)
// Cuda join point
// method_8((var_166: ManagedCuda.BasicTypes.CUdeviceptr), (var_171: ManagedCuda.BasicTypes.CUdeviceptr), (var_181: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_183: (System.Object [])) = [|var_166; var_171; var_181|]: (System.Object [])
let (var_184: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_32, var_1)
let (var_185: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_184.set_GridDimensions(var_185)
let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_184.set_BlockDimensions(var_186)
let (var_187: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_184.RunAsync(var_187, var_183)
let (var_189: (Union4 ref)) = (ref Union4Case1)
let (var_190: (float32 ref)) = (ref 0.000000f)
let (var_192: (Union4 ref)) = (ref Union4Case1)
let (var_193: (float32 ref)) = (ref 0.000000f)
let (var_194: float32) = method_15((var_176: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_189: (Union4 ref)), (var_192: (Union4 ref)))
let (var_195: string) = System.String.Format("{0}",var_194)
let (var_196: string) = String.concat ", " [|"Cost is:"; var_195|]
let (var_197: string) = System.String.Format("[{0}]",var_196)
System.Console.WriteLine(var_197)
var_193 := 1.000000f
let (var_198: float32) = method_15((var_176: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_189: (Union4 ref)), (var_192: (Union4 ref)))
let (var_199: float32) = (!var_193)
let (var_200: float32) = method_14((var_176: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_189: (Union4 ref)))
let (var_201: float32) = (var_199 / 2.000000f)
let (var_202: float32) = (!var_190)
let (var_203: float32) = (var_202 + var_201)
var_190 := var_203
let (var_204: float32) = method_14((var_176: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_189: (Union4 ref)))
let (var_205: float32) = (!var_190)
let (var_206: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_154: (Union0 ref)))
let (var_207: ManagedCuda.BasicTypes.SizeT) = var_206.Pointer
let (var_208: uint64) = uint64 var_207
let (var_209: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_208)
let (var_210: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_209)
let (var_211: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_135: (Union0 ref)))
let (var_212: ManagedCuda.BasicTypes.SizeT) = var_211.Pointer
let (var_213: uint64) = uint64 var_212
let (var_214: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_213)
let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_214)
let (var_216: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_88: (Union0 ref)))
let (var_217: ManagedCuda.BasicTypes.SizeT) = var_216.Pointer
let (var_218: uint64) = uint64 var_217
let (var_219: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_218)
let (var_220: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_219)
let (var_221: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_154: (Union0 ref)))
let (var_222: ManagedCuda.BasicTypes.SizeT) = var_221.Pointer
let (var_223: uint64) = uint64 var_222
let (var_224: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_223)
let (var_225: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_224)
// Cuda join point
// method_16((var_205: float32), (var_204: float32), (var_210: ManagedCuda.BasicTypes.CUdeviceptr), (var_215: ManagedCuda.BasicTypes.CUdeviceptr), (var_220: ManagedCuda.BasicTypes.CUdeviceptr), (var_225: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_227: (System.Object [])) = [|var_205; var_204; var_210; var_215; var_220; var_225|]: (System.Object [])
let (var_228: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_229: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_228.set_GridDimensions(var_229)
let (var_230: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_228.set_BlockDimensions(var_230)
let (var_231: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_228.RunAsync(var_231, var_227)
let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_121: (Union0 ref)))
let (var_233: ManagedCuda.BasicTypes.SizeT) = var_232.Pointer
let (var_234: uint64) = uint64 var_233
let (var_235: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_234)
let (var_236: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_235)
let (var_237: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_98: (Union0 ref)))
let (var_238: ManagedCuda.BasicTypes.SizeT) = var_237.Pointer
let (var_239: uint64) = uint64 var_238
let (var_240: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_239)
let (var_241: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_240)
let (var_242: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_154: (Union0 ref)))
let (var_243: ManagedCuda.BasicTypes.SizeT) = var_242.Pointer
let (var_244: uint64) = uint64 var_243
let (var_245: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_244)
let (var_246: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_245)
let (var_247: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_135: (Union0 ref)))
let (var_248: ManagedCuda.BasicTypes.SizeT) = var_247.Pointer
let (var_249: uint64) = uint64 var_248
let (var_250: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_249)
let (var_251: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_250)
let (var_252: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_121: (Union0 ref)))
let (var_253: ManagedCuda.BasicTypes.SizeT) = var_252.Pointer
let (var_254: uint64) = uint64 var_253
let (var_255: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_254)
let (var_256: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_255)
// Cuda join point
// method_18((var_236: ManagedCuda.BasicTypes.CUdeviceptr), (var_241: ManagedCuda.BasicTypes.CUdeviceptr), (var_246: ManagedCuda.BasicTypes.CUdeviceptr), (var_251: ManagedCuda.BasicTypes.CUdeviceptr), (var_256: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_258: (System.Object [])) = [|var_236; var_241; var_246; var_251; var_256|]: (System.Object [])
let (var_259: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_18", var_32, var_1)
let (var_260: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_259.set_GridDimensions(var_260)
let (var_261: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_259.set_BlockDimensions(var_261)
let (var_262: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_259.RunAsync(var_262, var_258)
let (var_263: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_264: ManagedCuda.BasicTypes.SizeT) = var_263.Pointer
let (var_265: uint64) = uint64 var_264
let (var_266: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_265)
let (var_267: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_266)
let (var_268: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_121: (Union0 ref)))
let (var_269: ManagedCuda.BasicTypes.SizeT) = var_268.Pointer
let (var_270: uint64) = uint64 var_269
let (var_271: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_270)
let (var_272: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_271)
let (var_273: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_78: (Union0 ref)))
let (var_274: ManagedCuda.BasicTypes.SizeT) = var_273.Pointer
let (var_275: uint64) = uint64 var_274
let (var_276: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_275)
let (var_277: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_276)
let (var_278: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
let (var_279: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_280: (float32 ref)) = (ref 1.000000f)
let (var_281: (float32 ref)) = (ref 1.000000f)
let (var_282: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_56, var_278, var_279, 6, 4, 2, var_280, var_267, 2, var_272, 2, var_281, var_277, 6)
if var_282 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_282)
let (var_283: int64) = 0L
let (var_284: int64) = 0L
let (var_285: int64) = 4L
let (var_286: int64) = 1L
let (var_287: int64) = 0L
let (var_288: int64) = 6L
let (var_289: int64) = 0L
let (var_290: int64) = 4L
method_20((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_78: (Union0 ref)), (var_283: int64), (var_284: int64), (var_285: int64), (var_286: int64), (var_287: int64), (var_288: int64), (var_289: int64), (var_290: int64))
var_176 := Union0Case1
var_154 := Union0Case1
var_135 := Union0Case1
var_121 := Union0Case1
var_98 := Union0Case1
var_88 := Union0Case1
var_78 := Union0Case1
var_69 := Union0Case1
var_60 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_291: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_291)
var_43 := Union0Case1
var_1.Dispose()

