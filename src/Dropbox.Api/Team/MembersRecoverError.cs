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
    /// <para>The members recover error object</para>
    /// </summary>
    public class MembersRecoverError
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<MembersRecoverError> Encoder = new MembersRecoverErrorEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<MembersRecoverError> Decoder = new MembersRecoverErrorDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="MembersRecoverError" />
        /// class.</para>
        /// </summary>
        public MembersRecoverError()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is UserUnrecoverable</para>
        /// </summary>
        public bool IsUserUnrecoverable
        {
            get
            {
                return this is UserUnrecoverable;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a UserUnrecoverable, or <c>null</c>.</para>
        /// </summary>
        public UserUnrecoverable AsUserUnrecoverable
        {
            get
            {
                return this as UserUnrecoverable;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is UserNotInTeam</para>
        /// </summary>
        public bool IsUserNotInTeam
        {
            get
            {
                return this is UserNotInTeam;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a UserNotInTeam, or <c>null</c>.</para>
        /// </summary>
        public UserNotInTeam AsUserNotInTeam
        {
            get
            {
                return this as UserNotInTeam;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Other</para>
        /// </summary>
        public bool IsOther
        {
            get
            {
                return this is Other;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Other, or <c>null</c>.</para>
        /// </summary>
        public Other AsOther
        {
            get
            {
                return this as Other;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is UserNotFound</para>
        /// </summary>
        public bool IsUserNotFound
        {
            get
            {
                return this is UserNotFound;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a UserNotFound, or <c>null</c>.</para>
        /// </summary>
        public UserNotFound AsUserNotFound
        {
            get
            {
                return this as UserNotFound;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="MembersRecoverError" />.</para>
        /// </summary>
        private class MembersRecoverErrorEncoder : enc.StructEncoder<MembersRecoverError>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(MembersRecoverError value, enc.IJsonWriter writer)
            {
                if (value is UserUnrecoverable)
                {
                    WriteProperty(".tag", "user_unrecoverable", writer, enc.StringEncoder.Instance);
                    UserUnrecoverable.Encoder.EncodeFields((UserUnrecoverable)value, writer);
                    return;
                }
                if (value is UserNotInTeam)
                {
                    WriteProperty(".tag", "user_not_in_team", writer, enc.StringEncoder.Instance);
                    UserNotInTeam.Encoder.EncodeFields((UserNotInTeam)value, writer);
                    return;
                }
                if (value is Other)
                {
                    WriteProperty(".tag", "other", writer, enc.StringEncoder.Instance);
                    Other.Encoder.EncodeFields((Other)value, writer);
                    return;
                }
                if (value is UserNotFound)
                {
                    WriteProperty(".tag", "user_not_found", writer, enc.StringEncoder.Instance);
                    UserNotFound.Encoder.EncodeFields((UserNotFound)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="MembersRecoverError" />.</para>
        /// </summary>
        private class MembersRecoverErrorDecoder : enc.UnionDecoder<MembersRecoverError>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="MembersRecoverError" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override MembersRecoverError Create()
            {
                return new MembersRecoverError();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override MembersRecoverError Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "user_unrecoverable":
                        return UserUnrecoverable.Decoder.DecodeFields(reader);
                    case "user_not_in_team":
                        return UserNotInTeam.Decoder.DecodeFields(reader);
                    default:
                        return Other.Decoder.DecodeFields(reader);
                    case "user_not_found":
                        return UserNotFound.Decoder.DecodeFields(reader);
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>The user is not recoverable.</para>
        /// </summary>
        public sealed class UserUnrecoverable : MembersRecoverError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<UserUnrecoverable> Encoder = new UserUnrecoverableEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<UserUnrecoverable> Decoder = new UserUnrecoverableDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="UserUnrecoverable" />
            /// class.</para>
            /// </summary>
            private UserUnrecoverable()
            {
            }

            /// <summary>
            /// <para>A singleton instance of UserUnrecoverable</para>
            /// </summary>
            public static readonly UserUnrecoverable Instance = new UserUnrecoverable();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="UserUnrecoverable" />.</para>
            /// </summary>
            private class UserUnrecoverableEncoder : enc.StructEncoder<UserUnrecoverable>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(UserUnrecoverable value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="UserUnrecoverable" />.</para>
            /// </summary>
            private class UserUnrecoverableDecoder : enc.StructDecoder<UserUnrecoverable>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="UserUnrecoverable"
                /// />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override UserUnrecoverable Create()
                {
                    return new UserUnrecoverable();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override UserUnrecoverable DecodeFields(enc.IJsonReader reader)
                {
                    return UserUnrecoverable.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The user is not a member of the team.</para>
        /// </summary>
        public sealed class UserNotInTeam : MembersRecoverError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<UserNotInTeam> Encoder = new UserNotInTeamEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<UserNotInTeam> Decoder = new UserNotInTeamDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="UserNotInTeam" />
            /// class.</para>
            /// </summary>
            private UserNotInTeam()
            {
            }

            /// <summary>
            /// <para>A singleton instance of UserNotInTeam</para>
            /// </summary>
            public static readonly UserNotInTeam Instance = new UserNotInTeam();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="UserNotInTeam" />.</para>
            /// </summary>
            private class UserNotInTeamEncoder : enc.StructEncoder<UserNotInTeam>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(UserNotInTeam value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="UserNotInTeam" />.</para>
            /// </summary>
            private class UserNotInTeamDecoder : enc.StructDecoder<UserNotInTeam>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="UserNotInTeam" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override UserNotInTeam Create()
                {
                    return new UserNotInTeam();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override UserNotInTeam DecodeFields(enc.IJsonReader reader)
                {
                    return UserNotInTeam.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The other object</para>
        /// </summary>
        public sealed class Other : MembersRecoverError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Other> Encoder = new OtherEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Other> Decoder = new OtherDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Other" /> class.</para>
            /// </summary>
            private Other()
            {
            }

            /// <summary>
            /// <para>A singleton instance of Other</para>
            /// </summary>
            public static readonly Other Instance = new Other();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherEncoder : enc.StructEncoder<Other>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Other value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Other" />.</para>
            /// </summary>
            private class OtherDecoder : enc.StructDecoder<Other>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Other" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Other Create()
                {
                    return new Other();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override Other DecodeFields(enc.IJsonReader reader)
                {
                    return Other.Instance;
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>No matching user found. The provided team_member_id, email, or external_id
        /// does not exist on this team.</para>
        /// </summary>
        public sealed class UserNotFound : MembersRecoverError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<UserNotFound> Encoder = new UserNotFoundEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<UserNotFound> Decoder = new UserNotFoundDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="UserNotFound" />
            /// class.</para>
            /// </summary>
            private UserNotFound()
            {
            }

            /// <summary>
            /// <para>A singleton instance of UserNotFound</para>
            /// </summary>
            public static readonly UserNotFound Instance = new UserNotFound();

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="UserNotFound" />.</para>
            /// </summary>
            private class UserNotFoundEncoder : enc.StructEncoder<UserNotFound>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(UserNotFound value, enc.IJsonWriter writer)
                {
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="UserNotFound" />.</para>
            /// </summary>
            private class UserNotFoundDecoder : enc.StructDecoder<UserNotFound>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="UserNotFound" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override UserNotFound Create()
                {
                    return new UserNotFound();
                }

                /// <summary>
                /// <para>Decode fields without ensuring start and end object.</para>
                /// </summary>
                /// <param name="reader">The json reader.</param>
                /// <returns>The decoded object.</returns>
                public override UserNotFound DecodeFields(enc.IJsonReader reader)
                {
                    return UserNotFound.Instance;
                }
            }

            #endregion
        }
    }
}
