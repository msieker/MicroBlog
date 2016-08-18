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
    /// <para>The members set permissions result object</para>
    /// </summary>
    public class MembersSetPermissionsResult
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<MembersSetPermissionsResult> Encoder = new MembersSetPermissionsResultEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<MembersSetPermissionsResult> Decoder = new MembersSetPermissionsResultDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="MembersSetPermissionsResult" />
        /// class.</para>
        /// </summary>
        /// <param name="teamMemberId">The member ID of the user to which the change was
        /// applied.</param>
        /// <param name="role">The role after the change.</param>
        public MembersSetPermissionsResult(string teamMemberId,
                                           AdminTier role)
        {
            if (teamMemberId == null)
            {
                throw new sys.ArgumentNullException("teamMemberId");
            }

            if (role == null)
            {
                throw new sys.ArgumentNullException("role");
            }

            this.TeamMemberId = teamMemberId;
            this.Role = role;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="MembersSetPermissionsResult" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public MembersSetPermissionsResult()
        {
        }

        /// <summary>
        /// <para>The member ID of the user to which the change was applied.</para>
        /// </summary>
        public string TeamMemberId { get; protected set; }

        /// <summary>
        /// <para>The role after the change.</para>
        /// </summary>
        public AdminTier Role { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="MembersSetPermissionsResult" />.</para>
        /// </summary>
        private class MembersSetPermissionsResultEncoder : enc.StructEncoder<MembersSetPermissionsResult>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(MembersSetPermissionsResult value, enc.IJsonWriter writer)
            {
                WriteProperty("team_member_id", value.TeamMemberId, writer, enc.StringEncoder.Instance);
                WriteProperty("role", value.Role, writer, Dropbox.Api.Team.AdminTier.Encoder);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="MembersSetPermissionsResult" />.</para>
        /// </summary>
        private class MembersSetPermissionsResultDecoder : enc.StructDecoder<MembersSetPermissionsResult>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="MembersSetPermissionsResult"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override MembersSetPermissionsResult Create()
            {
                return new MembersSetPermissionsResult();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(MembersSetPermissionsResult value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "team_member_id":
                        value.TeamMemberId = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "role":
                        value.Role = Dropbox.Api.Team.AdminTier.Decoder.Decode(reader);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }
        }

        #endregion
    }
}
