// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Team
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>The user's status as a member of a specific team.</para>
    /// </summary>
    public class TeamMemberStatus
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<TeamMemberStatus> Encoder = new TeamMemberStatusEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<TeamMemberStatus> Decoder = new TeamMemberStatusDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TeamMemberStatus" />
        /// class.</para>
        /// </summary>
        public TeamMemberStatus()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Active</para>
        /// </summary>
        public bool IsActive
        {
            get
            {
                return this is Active;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Active, or <c>null</c>.</para>
        /// </summary>
        public Active AsActive
        {
            get
            {
                return this as Active;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Invited</para>
        /// </summary>
        public bool IsInvited
        {
            get
            {
                return this is Invited;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Invited, or <c>null</c>.</para>
        /// </summary>
        public Invited AsInvited
        {
            get
            {
                return this as Invited;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Suspended</para>
        /// </summary>
        public bool IsSuspended
        {
            get
            {
                return this is Suspended;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Suspended, or <c>null</c>.</para>
        /// </summary>
        public Suspended AsSuspended
        {
            get
            {
                return this as Suspended;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Removed</para>
        /// </summary>
        public bool IsRemoved
        {
            get
            {
                return this is Removed;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Removed, or <c>null</c>.</para>
        /// </summary>
        public Removed AsRemoved
        {
            get
            {
                return this as Removed;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="TeamMemberStatus" />.</para>
        /// </summary>
        private class TeamMemberStatusEncoder : enc.StructEncoder<TeamMemberStatus>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(TeamMemberStatus value, enc.IJsonWriter writer)
            {
                if (value is Active)
                {
                    WriteProperty(".tag", "active", writer, enc.StringEncoder.Instance);
                    Active.Encoder.EncodeFields((Active)value, writer);
                    return;
                }
                if (value is Invited)
                {
                    WriteProperty(".tag", "invited", writer, enc.StringEncoder.Instance);
                    Invited.Encoder.EncodeFields((Invited)value, writer);
                    return;
                }
                if (value is Suspended)
                {
                    WriteProperty(".tag", "suspended", writer, enc.StringEncoder.Instance);
                    Suspended.Encoder.EncodeFields((Suspended)value, writer);
                    return;
                }
                if (value is Removed)
                {
                    WriteProperty(".tag", "removed", writer, enc.StringEncoder.Instance);
                    Removed.Encoder.EncodeFields((Removed)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="TeamMemberStatus" />.</para>
        /// </summary>
        private class TeamMemberStatusDecoder : enc.UnionDecoder<TeamMemberStatus>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="TeamMemberStatus" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override TeamMemberStatus Create()
            {
                return new TeamMemberStatus();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override TeamMemberStatus Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "active":
                        return Active.Decoder.DecodeFields(reader);
                    case "invited":
                        return Invited.Decoder.DecodeFields(reader);
                    case "suspended":
                        return Suspended.Decoder.DecodeFields(reader);
                    case "removed":
                        return Removed.Decoder.DecodeFields(reader);
                    default:
                        throw new sys.InvalidOperationException();
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>User has successfully joined the team.</para>
        /// </summary>
        public sealed class Active : TeamMemberStatus
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Active> Encoder = new ActiveEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Active> Decoder = new ActiveDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Active" /> class.</para>
            /// </summary>
            private Active()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Active</para>
            /// </summary>
            public static readonly Active Instance = new Active();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Active" />.</para>
            /// </summary>
            private class ActiveEncoder : enc.StructEncoder<Active>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Active value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Active" />.</para>
            /// </summary>
            private class ActiveDecoder : enc.StructDecoder<Active>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Active" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Active Create()
                {
                    return new Active();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Active DecodeFields(enc.IJsonReader reader)
                {
                    return Active.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>User has been invited to a team, but has not joined the team yet.</para>
        /// </summary>
        public sealed class Invited : TeamMemberStatus
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Invited> Encoder = new InvitedEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Invited> Decoder = new InvitedDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Invited" /> class.</para>
            /// </summary>
            private Invited()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Invited</para>
            /// </summary>
            public static readonly Invited Instance = new Invited();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Invited" />.</para>
            /// </summary>
            private class InvitedEncoder : enc.StructEncoder<Invited>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Invited value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Invited" />.</para>
            /// </summary>
            private class InvitedDecoder : enc.StructDecoder<Invited>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Invited" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Invited Create()
                {
                    return new Invited();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Invited DecodeFields(enc.IJsonReader reader)
                {
                    return Invited.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>User is no longer a member of the team, but the account can be un-suspended,
        /// re-establishing the user as a team member.</para>
        /// </summary>
        public sealed class Suspended : TeamMemberStatus
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Suspended> Encoder = new SuspendedEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Suspended> Decoder = new SuspendedDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Suspended" /> class.</para>
            /// </summary>
            private Suspended()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Suspended</para>
            /// </summary>
            public static readonly Suspended Instance = new Suspended();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Suspended" />.</para>
            /// </summary>
            private class SuspendedEncoder : enc.StructEncoder<Suspended>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Suspended value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Suspended" />.</para>
            /// </summary>
            private class SuspendedDecoder : enc.StructDecoder<Suspended>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Suspended" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Suspended Create()
                {
                    return new Suspended();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Suspended DecodeFields(enc.IJsonReader reader)
                {
                    return Suspended.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>User is no longer a member of the team. Removed users are only listed when
        /// include_removed is true in members/list.</para>
        /// </summary>
        public sealed class Removed : TeamMemberStatus
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Removed> Encoder = new RemovedEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Removed> Decoder = new RemovedDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Removed" /> class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public Removed(RemovedStatus value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Removed" /> class.</para>
            /// </summary>
            private Removed()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public RemovedStatus Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Removed" />.</para>
            /// </summary>
            private class RemovedEncoder : enc.StructEncoder<Removed>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Removed value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Team.RemovedStatus.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Removed" />.</para>
            /// </summary>
            private class RemovedDecoder : enc.StructDecoder<Removed>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Removed" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Removed Create()
                {
                    return new Removed();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Removed DecodeFields(enc.IJsonReader reader)
                {
                    return new Removed(Dropbox.Api.Team.RemovedStatus.Decoder.DecodeFields(reader));
                }
            }

            #endregion
        }
    }
}
