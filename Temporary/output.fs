module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple1 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, float mem_1){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer0)(float, float);
    __global__ void method_5(float * var_0, float * var_1);
    __global__ void method_8(float * var_0, float * var_1);
    __global__ void method_10(float * var_0, float * var_1, float * var_2);
    __device__ char method_6(long long int * var_0);
    __device__ float method_7(float var_0, float var_1);
    __device__ char method_9(long long int * var_0, float * var_1);
    
    __global__ void method_5(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_6(var_5)) {
            long long int var_7 = var_5[0];
            long long int var_8 = (var_7 + 1);
            char var_9 = (var_7 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_7 < 1);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_13 = (var_7 * 4);
            char var_15;
            if (var_9) {
                var_15 = (var_7 < 1);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            float var_17[1];
            long long int var_18 = threadIdx.x;
            long long int var_19[1];
            var_19[0] = 0;
            while (method_6(var_19)) {
                long long int var_21 = var_19[0];
                long long int var_22 = (var_21 + 1);
                long long int var_23 = (4 * var_21);
                long long int var_24 = (var_18 + var_23);
                char var_25 = (var_24 < 4);
                if (var_25) {
                    char var_26 = (var_21 >= 0);
                    char var_28;
                    if (var_26) {
                        var_28 = (var_21 < 1);
                    } else {
                        var_28 = 0;
                    }
                    char var_29 = (var_28 == 0);
                    if (var_29) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_30 = (var_24 >= 0);
                    char var_31 = (var_30 == 0);
                    if (var_31) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_32 = (var_13 + var_24);
                    float var_33 = var_0[var_32];
                    var_17[var_21] = var_33;
                } else {
                }
                var_19[0] = var_22;
            }
            long long int var_34 = var_19[0];
            FunPointer0 var_37 = method_7;
            float var_38 = cub::BlockReduce<float,4,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_17, var_37);
            __shared__ float var_39[1];
            long long int var_40 = threadIdx.x;
            char var_41 = (var_40 == 0);
            if (var_41) {
                var_39[0] = var_38;
            } else {
            }
            __syncthreads();
            float var_42 = var_39[0];
            float var_45[1];
            long long int var_46[1];
            var_46[0] = 0;
            while (method_6(var_46)) {
                long long int var_48 = var_46[0];
                long long int var_49 = (var_48 + 1);
                long long int var_50 = (4 * var_48);
                long long int var_51 = (var_18 + var_50);
                char var_52 = (var_51 < 4);
                if (var_52) {
                    char var_53 = (var_51 >= 0);
                    char var_54 = (var_53 == 0);
                    if (var_54) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_55 = (var_13 + var_51);
                    char var_56 = (var_48 >= 0);
                    char var_58;
                    if (var_56) {
                        var_58 = (var_48 < 1);
                    } else {
                        var_58 = 0;
                    }
                    char var_59 = (var_58 == 0);
                    if (var_59) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_60 = var_17[var_48];
                    float var_61 = (var_60 - var_42);
                    float var_62 = exp(var_61);
                    char var_64;
                    if (var_56) {
                        var_64 = (var_48 < 1);
                    } else {
                        var_64 = 0;
                    }
                    char var_65 = (var_64 == 0);
                    if (var_65) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_45[var_48] = var_62;
                } else {
                }
                var_46[0] = var_49;
            }
            long long int var_66 = var_46[0];
            float var_67 = cub::BlockReduce<float,4,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_45);
            __shared__ float var_68[1];
            long long int var_69 = threadIdx.x;
            char var_70 = (var_69 == 0);
            if (var_70) {
                var_68[0] = var_67;
            } else {
            }
            __syncthreads();
            float var_71 = var_68[0];
            long long int var_72[1];
            var_72[0] = 0;
            while (method_6(var_72)) {
                long long int var_74 = var_72[0];
                long long int var_75 = (var_74 + 1);
                long long int var_76 = (4 * var_74);
                long long int var_77 = (var_18 + var_76);
                char var_78 = (var_77 < 4);
                if (var_78) {
                    char var_79 = (var_77 >= 0);
                    char var_80 = (var_79 == 0);
                    if (var_80) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_81 = (var_13 + var_77);
                    char var_82 = (var_74 >= 0);
                    char var_84;
                    if (var_82) {
                        var_84 = (var_74 < 1);
                    } else {
                        var_84 = 0;
                    }
                    char var_85 = (var_84 == 0);
                    if (var_85) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_86 = var_45[var_74];
                    float var_87 = var_1[var_81];
                    float var_88 = (var_86 / var_71);
                    var_1[var_81] = var_88;
                } else {
                }
                var_72[0] = var_75;
            }
            long long int var_89 = var_72[0];
            var_5[0] = var_8;
        }
        long long int var_90 = var_5[0];
    }
    __global__ void method_8(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_6(var_5)) {
            long long int var_7 = var_5[0];
            long long int var_8 = (var_7 + 1);
            char var_9 = (var_7 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_7 < 1);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_13 = (var_7 * 4);
            char var_15;
            if (var_9) {
                var_15 = (var_7 < 1);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.x;
            long long int var_18 = blockIdx.x;
            long long int var_19 = (4 * var_18);
            long long int var_20 = (var_17 + var_19);
            float var_21 = 0;
            long long int var_22[1];
            float var_23[1];
            var_22[0] = var_20;
            var_23[0] = var_21;
            while (method_9(var_22, var_23)) {
                long long int var_25 = var_22[0];
                float var_26 = var_23[0];
                long long int var_27 = (var_25 + 4);
                char var_28 = (var_25 >= 0);
                char var_30;
                if (var_28) {
                    var_30 = (var_25 < 4);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_32 = (var_13 + var_25);
                char var_34;
                if (var_28) {
                    var_34 = (var_25 < 4);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                float var_36 = var_0[var_32];
                float var_37[1];
                float var_38 = var_37[0];
                float var_39[1];
                float var_40 = var_39[0];
                cub::BlockScan<float,4,cub::BLOCK_SCAN_RAKING_MEMOIZE,1,1>().InclusiveSum(var_36, var_38, var_40);
                float var_41 = (var_26 + var_38);
                float var_42 = var_1[var_32];
                var_1[var_32] = var_41;
                float var_43 = (var_26 + var_40);
                var_22[0] = var_27;
                var_23[0] = var_43;
            }
            long long int var_44 = var_22[0];
            float var_45 = var_23[0];
            var_5[0] = var_8;
        }
        long long int var_46 = var_5[0];
    }
    __global__ void method_10(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_6(var_6)) {
            long long int var_8 = var_6[0];
            long long int var_9 = (var_8 + 1);
            char var_10 = (var_8 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_8 < 1);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_14 = (var_8 * 4);
            char var_16;
            if (var_10) {
                var_16 = (var_8 < 1);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            Tuple1 var_18[1];
            long long int var_19 = threadIdx.x;
            long long int var_20[1];
            var_20[0] = 0;
            while (method_6(var_20)) {
                long long int var_22 = var_20[0];
                long long int var_23 = (var_22 + 1);
                long long int var_24 = (4 * var_22);
                long long int var_25 = (var_19 + var_24);
                char var_26 = (var_25 < 4);
                if (var_26) {
                    char var_27 = (var_22 >= 0);
                    char var_29;
                    if (var_27) {
                        var_29 = (var_22 < 1);
                    } else {
                        var_29 = 0;
                    }
                    char var_30 = (var_29 == 0);
                    if (var_30) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_31 = (var_25 >= 0);
                    char var_32 = (var_31 == 0);
                    if (var_32) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_33 = (var_14 + var_25);
                    float var_34 = var_0[var_33];
                    float var_35 = var_1[var_33];
                    var_18[var_22] = make_Tuple1(var_34, var_35);
                } else {
                }
                var_20[0] = var_23;
            }
            long long int var_36 = var_20[0];
            float var_38[1];
            long long int var_39[1];
            var_39[0] = 0;
            while (method_6(var_39)) {
                long long int var_41 = var_39[0];
                long long int var_42 = (var_41 + 1);
                long long int var_43 = (4 * var_41);
                long long int var_44 = (var_19 + var_43);
                char var_45 = (var_44 < 4);
                if (var_45) {
                    char var_46 = (var_41 >= 0);
                    char var_48;
                    if (var_46) {
                        var_48 = (var_41 < 1);
                    } else {
                        var_48 = 0;
                    }
                    char var_49 = (var_48 == 0);
                    if (var_49) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_50 = var_18[var_41];
                    float var_51 = var_50.mem_0;
                    float var_52 = var_50.mem_1;
                    float var_53 = (var_51 * var_52);
                    char var_55;
                    if (var_46) {
                        var_55 = (var_41 < 1);
                    } else {
                        var_55 = 0;
                    }
                    char var_56 = (var_55 == 0);
                    if (var_56) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_38[var_41] = var_53;
                } else {
                }
                var_39[0] = var_42;
            }
            long long int var_57 = var_39[0];
            float var_58 = cub::BlockReduce<float,4,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_38);
            __shared__ float var_59[1];
            long long int var_60 = threadIdx.x;
            char var_61 = (var_60 == 0);
            if (var_61) {
                var_59[0] = var_58;
            } else {
            }
            __syncthreads();
            float var_62 = var_59[0];
            long long int var_63[1];
            var_63[0] = 0;
            while (method_6(var_63)) {
                long long int var_65 = var_63[0];
                long long int var_66 = (var_65 + 1);
                long long int var_67 = (4 * var_65);
                long long int var_68 = (var_19 + var_67);
                char var_69 = (var_68 < 4);
                if (var_69) {
                    char var_70 = (var_68 >= 0);
                    char var_71 = (var_70 == 0);
                    if (var_71) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_72 = (var_14 + var_68);
                    char var_73 = (var_65 >= 0);
                    char var_75;
                    if (var_73) {
                        var_75 = (var_65 < 1);
                    } else {
                        var_75 = 0;
                    }
                    char var_76 = (var_75 == 0);
                    if (var_76) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_77 = var_18[var_65];
                    float var_78 = var_77.mem_0;
                    float var_79 = var_77.mem_1;
                    float var_80 = var_2[var_72];
                    float var_81 = (var_79 * var_78);
                    float var_82 = (1 - var_78);
                    float var_83 = (var_81 * var_82);
                    float var_84 = (var_62 - var_81);
                    float var_85 = (var_78 * var_84);
                    float var_86 = (var_83 - var_85);
                    var_2[var_72] = var_86;
                } else {
                }
                var_63[0] = var_66;
            }
            long long int var_87 = var_63[0];
            var_6[0] = var_9;
        }
        long long int var_88 = var_6[0];
    }
    __device__ char method_6(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ float method_7(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_9(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 4);
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
and EnvStack2 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: EnvStack2
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env3) = var_1.Peek()
        let (var_7: EnvStack2) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_11((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
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
    let (var_25: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_16))
    let (var_26: (Union0 ref)) = var_5.mem_0
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_26: (Union0 ref)))
    var_0.CopyToHost(var_25, var_27)
    let (var_28: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_29: string) = ""
    let (var_30: int64) = 0L
    method_12((var_28: System.Text.StringBuilder), (var_30: int64))
    let (var_31: System.Text.StringBuilder) = var_28.AppendLine("[|")
    method_13((var_28: System.Text.StringBuilder), (var_29: string), (var_25: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_32: int64) = 0L
    method_12((var_28: System.Text.StringBuilder), (var_32: int64))
    let (var_33: System.Text.StringBuilder) = var_28.AppendLine("|]")
    let (var_34: string) = var_28.ToString()
    let (var_35: string) = System.String.Format("{0}",var_34)
    System.Console.WriteLine(var_35)
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_12((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_13((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
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
        method_14((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_15((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_14((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_14((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_15((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
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
        method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
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
        method_14((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_15((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
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
        method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
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
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_10: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
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
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:/cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
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
let (var_39: float) = (0.100000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_53: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_52)
let (var_54: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_53.SetStream(var_54)
let (var_55: int64) = 16L
let (var_56: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_55: int64))
let (var_57: (Union0 ref)) = var_56.mem_0
let (var_58: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
let (var_59: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
var_53.GenerateNormal32(var_58, var_59, 0.000000f, 1.000000f)
let (var_60: int64) = 16L
let (var_61: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_60: int64))
let (var_62: (Union0 ref)) = var_61.mem_0
let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
var_53.GenerateNormal32(var_63, var_64, 1.000000f, 0.000000f)
let (var_68: int64) = 16L
let (var_69: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_68: int64))
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
let (var_71: (Union0 ref)) = var_69.mem_0
let (var_72: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
// Cuda join point
// method_5((var_70: ManagedCuda.BasicTypes.CUdeviceptr), (var_72: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_73: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_5", var_32, var_1)
let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_73.set_GridDimensions(var_74)
let (var_75: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_73.set_BlockDimensions(var_75)
let (var_76: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_78: (System.Object [])) = [|var_70; var_72|]: (System.Object [])
var_73.RunAsync(var_76, var_78)
let (var_79: int64) = 16L
let (var_80: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_79: int64))
let (var_81: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
let (var_82: (Union0 ref)) = var_80.mem_0
let (var_83: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_82: (Union0 ref)))
// Cuda join point
// method_8((var_81: ManagedCuda.BasicTypes.CUdeviceptr), (var_83: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_32, var_1)
let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_84.set_GridDimensions(var_85)
let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_84.set_BlockDimensions(var_86)
let (var_87: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_89: (System.Object [])) = [|var_81; var_83|]: (System.Object [])
var_84.RunAsync(var_87, var_89)
let (var_93: int64) = 16L
let (var_94: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_93: int64))
let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
let (var_97: (Union0 ref)) = var_94.mem_0
let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_97: (Union0 ref)))
// Cuda join point
// method_10((var_95: ManagedCuda.BasicTypes.CUdeviceptr), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_99: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_10", var_32, var_1)
let (var_100: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_99.set_GridDimensions(var_100)
let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_99.set_BlockDimensions(var_101)
let (var_102: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_104: (System.Object [])) = [|var_95; var_96; var_98|]: (System.Object [])
var_99.RunAsync(var_102, var_104)
let (var_105: int64) = 0L
let (var_106: int64) = 0L
let (var_107: int64) = 4L
let (var_108: int64) = 1L
let (var_109: int64) = 0L
let (var_110: int64) = 1L
let (var_111: int64) = 0L
let (var_112: int64) = 4L
method_11((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_56: EnvStack2), (var_105: int64), (var_106: int64), (var_107: int64), (var_108: int64), (var_109: int64), (var_110: int64), (var_111: int64), (var_112: int64))
let (var_113: int64) = 0L
let (var_114: int64) = 0L
let (var_115: int64) = 4L
let (var_116: int64) = 1L
let (var_117: int64) = 0L
let (var_118: int64) = 1L
let (var_119: int64) = 0L
let (var_120: int64) = 4L
method_11((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_94: EnvStack2), (var_113: int64), (var_114: int64), (var_115: int64), (var_116: int64), (var_117: int64), (var_118: int64), (var_119: int64), (var_120: int64))
var_97 := Union0Case1
var_82 := Union0Case1
var_71 := Union0Case1
var_62 := Union0Case1
var_57 := Union0Case1
var_53.Dispose()
var_51.Dispose()
let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_121)
var_46 := Union0Case1
var_1.Dispose()

