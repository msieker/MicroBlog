// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.TeamPolicies
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>Policies governing sharing within and outside of the team.</para>
    /// </summary>
    /// <seealso cref="TeamMemberPolicies" />
    public class TeamSharingPolicies
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<TeamSharingPolicies> Encoder = new TeamSharingPoliciesEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<TeamSharingPolicies> Decoder = new TeamSharingPoliciesDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TeamSharingPolicies" />
        /// class.</para>
        /// </summary>
        /// <param name="sharedFolderMemberPolicy">Who can join folders shared by team
        /// members.</param>
        /// <param name="sharedFolderJoinPolicy">Which shared folders team members can
        /// join.</param>
        /// <param name="sharedLinkCreatePolicy">What is the visibility of newly created shared
        /// links.</param>
        public TeamSharingPolicies(SharedFolderMemberPolicy sharedFolderMemberPolicy,
                                   SharedFolderJoinPolicy sharedFolderJoinPolicy,
                                   SharedLinkCreatePolicy sharedLinkCreatePolicy)
        {
            if (sharedFolderMemberPolicy == null)
            {
                throw new sys.ArgumentNullException("sharedFolderMemberPolicy");
            }

            if (sharedFolderJoinPolicy == null)
            {
                throw new sys.ArgumentNullException("sharedFolderJoinPolicy");
            }

            if (sharedLinkCreatePolicy == null)
            {
                throw new sys.ArgumentNullException("sharedLinkCreatePolicy");
            }

            this.SharedFolderMemberPolicy = sharedFolderMemberPolicy;
            this.SharedFolderJoinPolicy = sharedFolderJoinPolicy;
            this.SharedLinkCreatePolicy = sharedLinkCreatePolicy;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TeamSharingPolicies" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public TeamSharingPolicies()
        {
        }

        /// <summary>
        /// <para>Who can join folders shared by team members.</para>
        /// </summary>
        public SharedFolderMemberPolicy SharedFolderMemberPolicy { get; protected set; }

        /// <summary>
        /// <para>Which shared folders team members can join.</para>
        /// </summary>
        public SharedFolderJoinPolicy SharedFolderJoinPolicy { get; protected set; }

        /// <summary>
        /// <para>What is the visibility of newly created shared links.</para>
        /// </summary>
        public SharedLinkCreatePolicy SharedLinkCreatePolicy { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="TeamSharingPolicies" />.</para>
        /// </summary>
        private class TeamSharingPoliciesEncoder : enc.StructEncoder<TeamSharingPolicies>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(TeamSharingPolicies value, enc.IJsonWriter writer)
            {
                WriteProperty("shared_folder_member_policy", value.SharedFolderMemberPolicy, writer, Dropbox.Api.TeamPolicies.SharedFolderMemberPolicy.Encoder);
                WriteProperty("shared_folder_join_policy", value.SharedFolderJoinPolicy, writer, Dropbox.Api.TeamPolicies.SharedFolderJoinPolicy.Encoder);
                WriteProperty("shared_link_create_policy", value.SharedLinkCreatePolicy, writer, Dropbox.Api.TeamPolicies.SharedLinkCreatePolicy.Encoder);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="TeamSharingPolicies" />.</para>
        /// </summary>
        private class TeamSharingPoliciesDecoder : enc.StructDecoder<TeamSharingPolicies>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="TeamSharingPolicies" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override TeamSharingPolicies Create()
            {
                return new TeamSharingPolicies();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(TeamSharingPolicies value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "shared_folder_member_policy":
                        value.SharedFolderMemberPolicy = Dropbox.Api.TeamPolicies.SharedFolderMemberPolicy.Decoder.Decode(reader);
                        break;
                    case "shared_folder_join_policy":
                        value.SharedFolderJoinPolicy = Dropbox.Api.TeamPolicies.SharedFolderJoinPolicy.Decoder.Decode(reader);
                        break;
                    case "shared_link_create_policy":
                        value.SharedLinkCreatePolicy = Dropbox.Api.TeamPolicies.SharedLinkCreatePolicy.Decoder.Decode(reader);
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
