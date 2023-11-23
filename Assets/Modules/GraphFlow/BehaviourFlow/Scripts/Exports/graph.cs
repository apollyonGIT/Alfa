// generated by vnpktcoder.
using Foundation.Packets;
using System.IO;
namespace AutoCode.Packets.BehaviourFlowExports {
    public enum ExternalType : byte {
        External = 1,
        Constant = 2,
        SharedInt = 3,
        SharedFloat = 4,
    }
    public enum ExpressionType : byte {
        Constant = 1,
        Expression = 2,
    }
    public enum ParamType : byte {
        Constant = 1,
        Expression = 2,
        String = 3,
    }
    public struct ExpressionExternal : IPacketData {
        public Enum<ExternalType, u8> et;
        public cuint index;
        public ExpressionExternal(BinaryReader r) {
            et = new Enum<ExternalType, u8>((ExternalType)new u8(r).value);
            index = new cuint(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!et.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            et.save_to(w);
            index.save_to(w);
        }
    }
    public struct Expression : IPacketData {
        public List<u32> byte_code;
        public List<ExpressionExternal> externals;
        public List<cuint> functions;
        public Expression(BinaryReader r) {
            byte_code = read_byte_code_0(r);
            externals = read_externals_0(r);
            functions = read_functions_0(r);
        }
        static readonly int[] byte_code_size_hint = new int[] { 1048576 };
        static readonly int[] externals_size_hint = new int[] { 255 };
        static readonly int[] functions_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!byte_code.validate(byte_code_size_hint, 0)) return false;
            if (!externals.validate(externals_size_hint, 0)) return false;
            if (!functions.validate(functions_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            byte_code.save_to(w);
            externals.save_to(w);
            functions.save_to(w);
        }
        static List<u32> read_byte_code_0(BinaryReader r) {
            var ret = new List<u32>(r);
            foreach (ref var e in ret) {
                e = new u32(r);
            }
            return ret;
        }
        static List<ExpressionExternal> read_externals_0(BinaryReader r) {
            var ret = new List<ExpressionExternal>(r);
            foreach (ref var e in ret) {
                e = new ExpressionExternal(r);
            }
            return ret;
        }
        static List<cuint> read_functions_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
    }
    public struct Head : IPacketData {
        public Array<u8> sign;
        public cuint version;
        public Head(BinaryReader r) {
            sign = read_sign_0(r);
            version = new cuint(r);
        }
        static readonly int[] sign_size_hint = new int[] { 4 };
        public bool validate(int[] size_hint, int offset) {
            if (!sign.validate(sign_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            sign.save_to(w);
            version.save_to(w);
        }
        static Array<u8> read_sign_0(BinaryReader r) {
            var ret = new Array<u8>(4);
            foreach (ref var e in ret) {
                e = new u8(r);
            }
            return ret;
        }
    }
    public struct Body : IPacketData {
        public List<String> strings;
        public List<cuint> shared_ints;
        public List<cuint> shared_floats;
        public List<u32> constants;
        public List<Expression> expressions;
        public cuint node_count;
        public Body(BinaryReader r) {
            strings = read_strings_0(r);
            shared_ints = read_shared_ints_0(r);
            shared_floats = read_shared_floats_0(r);
            constants = read_constants_0(r);
            expressions = read_expressions_0(r);
            node_count = new cuint(r);
        }
        static readonly int[] strings_size_hint = new int[] { 1024, 1024 };
        static readonly int[] shared_ints_size_hint = new int[] { 1024 };
        static readonly int[] shared_floats_size_hint = new int[] { 1024 };
        static readonly int[] constants_size_hint = new int[] { 1024 };
        static readonly int[] expressions_size_hint = new int[] { 1024 };
        public bool validate(int[] size_hint, int offset) {
            if (!strings.validate(strings_size_hint, 0)) return false;
            if (!shared_ints.validate(shared_ints_size_hint, 0)) return false;
            if (!shared_floats.validate(shared_floats_size_hint, 0)) return false;
            if (!constants.validate(constants_size_hint, 0)) return false;
            if (!expressions.validate(expressions_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            strings.save_to(w);
            shared_ints.save_to(w);
            shared_floats.save_to(w);
            constants.save_to(w);
            expressions.save_to(w);
            node_count.save_to(w);
        }
        static List<String> read_strings_0(BinaryReader r) {
            var ret = new List<String>(r);
            foreach (ref var e in ret) {
                e = new String(r);
            }
            return ret;
        }
        static List<cuint> read_shared_ints_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        static List<cuint> read_shared_floats_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        static List<u32> read_constants_0(BinaryReader r) {
            var ret = new List<u32>(r);
            foreach (ref var e in ret) {
                e = new u32(r);
            }
            return ret;
        }
        static List<Expression> read_expressions_0(BinaryReader r) {
            var ret = new List<Expression>(r);
            foreach (ref var e in ret) {
                e = new Expression(r);
            }
            return ret;
        }
    }
    public struct ExpressionRef : IPacketData {
        public Enum<ExpressionType, u8> ty;
        public cuint index;
        public ExpressionRef(BinaryReader r) {
            ty = new Enum<ExpressionType, u8>((ExpressionType)new u8(r).value);
            index = new cuint(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!ty.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            ty.save_to(w);
            index.save_to(w);
        }
    }
    public struct ParamRef : IPacketData {
        public Enum<ParamType, u8> ty;
        public cuint index;
        public ParamRef(BinaryReader r) {
            ty = new Enum<ParamType, u8>((ParamType)new u8(r).value);
            index = new cuint(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!ty.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            ty.save_to(w);
            index.save_to(w);
        }
    }
    public struct MethodInfo : IPacketData {
        public cuint name_index;
        public List<ParamRef> args;
        public MethodInfo(BinaryReader r) {
            name_index = new cuint(r);
            args = read_args_0(r);
        }
        static readonly int[] args_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!args.validate(args_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            name_index.save_to(w);
            args.save_to(w);
        }
        static List<ParamRef> read_args_0(BinaryReader r) {
            var ret = new List<ParamRef>(r);
            foreach (ref var e in ret) {
                e = new ParamRef(r);
            }
            return ret;
        }
    }
    public class Success : IPacket {
        public const uint PID = 1;
        public uint pid => PID;
        public Success() { }
        public Success(BinaryReader r) {
        }
        public bool validate(int[] size_hint, int offset) {
            return true;
        }
        public void save_to(BinaryWriter w) {
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Failed : IPacket {
        public const uint PID = 2;
        public uint pid => PID;
        public Failed() { }
        public Failed(BinaryReader r) {
        }
        public bool validate(int[] size_hint, int offset) {
            return true;
        }
        public void save_to(BinaryWriter w) {
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Condition : IPacket {
        public const uint PID = 3;
        public uint pid => PID;
        public Condition() { }
        public ExpressionRef cond;
        public Condition(BinaryReader r) {
            cond = new ExpressionRef(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!cond.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            cond.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Delay : IPacket {
        public const uint PID = 4;
        public uint pid => PID;
        public Delay() { }
        public ExpressionRef count;
        public Delay(BinaryReader r) {
            count = new ExpressionRef(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!count.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            count.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class DelayCond : IPacket {
        public const uint PID = 5;
        public uint pid => PID;
        public DelayCond() { }
        public ExpressionRef count;
        public ExpressionRef cond;
        public DelayCond(BinaryReader r) {
            count = new ExpressionRef(r);
            cond = new ExpressionRef(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!count.validate(null, 0)) return false;
            if (!cond.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            count.save_to(w);
            cond.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Not : IPacket {
        public const uint PID = 6;
        public uint pid => PID;
        public Not() { }
        public Nullable<cuint> child;
        public Not(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                if ((_opt[0] & 1) != 0) {
                    child = new cuint(r);
                } else {
                    child = default;
                }
            }
        }
        public bool validate(int[] size_hint, int offset) {
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (child.has_value) _opt[0] |= 1;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            child.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Loop : IPacket {
        public const uint PID = 7;
        public uint pid => PID;
        public Loop() { }
        public u8 mode;
        public ExpressionRef interval;
        public ExpressionRef count;
        public Nullable<cuint> child;
        public Loop(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                mode = new u8(r);
                interval = new ExpressionRef(r);
                count = new ExpressionRef(r);
                if ((_opt[0] & 1) != 0) {
                    child = new cuint(r);
                } else {
                    child = default;
                }
            }
        }
        public bool validate(int[] size_hint, int offset) {
            if (!interval.validate(null, 0)) return false;
            if (!count.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (child.has_value) _opt[0] |= 1;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            mode.save_to(w);
            interval.save_to(w);
            count.save_to(w);
            child.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Sequence : IPacket {
        public const uint PID = 8;
        public uint pid => PID;
        public Sequence() { }
        public List<cuint> children;
        public Sequence(BinaryReader r) {
            children = read_children_0(r);
        }
        static readonly int[] children_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!children.validate(children_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            children.save_to(w);
        }
        static List<cuint> read_children_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Selector : IPacket {
        public const uint PID = 9;
        public uint pid => PID;
        public Selector() { }
        public List<cuint> children;
        public Selector(BinaryReader r) {
            children = read_children_0(r);
        }
        static readonly int[] children_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!children.validate(children_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            children.save_to(w);
        }
        static List<cuint> read_children_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Action : IPacket {
        public const uint PID = 10;
        public uint pid => PID;
        public Action() { }
        public Nullable<MethodInfo> method;
        public Action(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                if ((_opt[0] & 1) != 0) {
                    method = new MethodInfo(r);
                } else {
                    method = default;
                }
            }
        }
        public bool validate(int[] size_hint, int offset) {
            if (!method.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (method.has_value) _opt[0] |= 1;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            method.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Branch : IPacket {
        public const uint PID = 11;
        public uint pid => PID;
        public Branch() { }
        public ExpressionRef cond;
        public Nullable<cuint> true_part;
        public Nullable<cuint> false_part;
        public Branch(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                cond = new ExpressionRef(r);
                if ((_opt[0] & 1) != 0) {
                    true_part = new cuint(r);
                } else {
                    true_part = default;
                }
                if ((_opt[0] & 2) != 0) {
                    false_part = new cuint(r);
                } else {
                    false_part = default;
                }
            }
        }
        public bool validate(int[] size_hint, int offset) {
            if (!cond.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (true_part.has_value) _opt[0] |= 1;
                if (false_part.has_value) _opt[0] |= 2;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            cond.save_to(w);
            true_part.save_to(w);
            false_part.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class ShareInt : IPacket {
        public const uint PID = 12;
        public uint pid => PID;
        public ShareInt() { }
        public cuint target_index;
        public ExpressionRef value;
        public ShareInt(BinaryReader r) {
            target_index = new cuint(r);
            value = new ExpressionRef(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!value.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            target_index.save_to(w);
            value.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class ShareFloat : IPacket {
        public const uint PID = 13;
        public uint pid => PID;
        public ShareFloat() { }
        public cuint target_index;
        public ExpressionRef value;
        public ShareFloat(BinaryReader r) {
            target_index = new cuint(r);
            value = new ExpressionRef(r);
        }
        public bool validate(int[] size_hint, int offset) {
            if (!value.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            target_index.save_to(w);
            value.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class State : IPacket {
        public const uint PID = 14;
        public uint pid => PID;
        public State() { }
        public ExpressionRef cond;
        public Nullable<cuint> child;
        public State(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                cond = new ExpressionRef(r);
                if ((_opt[0] & 1) != 0) {
                    child = new cuint(r);
                } else {
                    child = default;
                }
            }
        }
        public bool validate(int[] size_hint, int offset) {
            if (!cond.validate(null, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (child.has_value) _opt[0] |= 1;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            cond.save_to(w);
            child.save_to(w);
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class Parallel : IPacket {
        public const uint PID = 15;
        public uint pid => PID;
        public Parallel() { }
        public u8 mode;
        public List<cuint> children;
        public Parallel(BinaryReader r) {
            mode = new u8(r);
            children = read_children_0(r);
        }
        static readonly int[] children_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!children.validate(children_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            mode.save_to(w);
            children.save_to(w);
        }
        static List<cuint> read_children_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        public virtual void post_process(IPacketReader reader) { }
    }
    public class BranchEx : IPacket {
        public const uint PID = 16;
        public uint pid => PID;
        public BranchEx() { }
        public ExpressionRef value;
        public Nullable<cuint> def;
        public List<cuint> children;
        public BranchEx(BinaryReader r) {
            unsafe {
                var _opt = stackalloc byte[1];
                for (int i = 0; i < 1; ++i) _opt[i] = r.ReadByte();
                value = new ExpressionRef(r);
                if ((_opt[0] & 1) != 0) {
                    def = new cuint(r);
                } else {
                    def = default;
                }
                children = read_children_0(r);
            }
        }
        static readonly int[] children_size_hint = new int[] { 255 };
        public bool validate(int[] size_hint, int offset) {
            if (!value.validate(null, 0)) return false;
            if (!children.validate(children_size_hint, 0)) return false;
            return true;
        }
        public void save_to(BinaryWriter w) {
            unsafe {
                byte* _opt = stackalloc byte[1];
                if (def.has_value) _opt[0] |= 1;
                for (int i = 0; i < 1; ++i) w.Write(_opt[i]);
            }
            value.save_to(w);
            def.save_to(w);
            children.save_to(w);
        }
        static List<cuint> read_children_0(BinaryReader r) {
            var ret = new List<cuint>(r);
            foreach (ref var e in ret) {
                e = new cuint(r);
            }
            return ret;
        }
        public virtual void post_process(IPacketReader reader) { }
    }
}
