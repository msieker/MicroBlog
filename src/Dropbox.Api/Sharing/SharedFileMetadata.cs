// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Sharing
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>Properties of the shared file.</para>
    /// </summary>
    public class SharedFileMetadata
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<SharedFileMetadata> Encoder = new SharedFileMetadataEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<SharedFileMetadata> Decoder = new SharedFileMetadataDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SharedFileMetadata" />
        /// class.</para>
        /// </summary>
        /// <param name="policy">Policies governing this shared file.</param>
        /// <param name="previewUrl">URL for displaying a web preview of the shared
        /// file.</param>
        /// <param name="name">The name of this file.</param>
        /// <param name="id">The ID of the file.</param>
        /// <param name="permissions">The sharing permissions that requesting user has on this
        /// file. This corresponds to the entries given in <see
        /// cref="Dropbox.Api.Sharing.GetFileMetadataBatchArg.Actions" /> or <see
        /// cref="Dropbox.Api.Sharing.GetFileMetadataArg.Actions" />.</param>
        /// <param name="ownerTeam">The team that owns the file. This field is not present if
        /// the file is not owned by a team.</param>
        /// <param name="parentSharedFolderId">The ID of the parent shared folder. This field
        /// is present only if the file is contained within a shared folder.</param>
        /// <param name="pathLower">The lower-case full path of this file. Absent for unmounted
        /// files.</param>
        /// <param name="pathDisplay">The cased path to be used for display purposes only. In
        /// rare instances the casing will not correctly match the user's filesystem, but this
        /// behavior will match the path provided in the Core API v1. Absent for unmounted
        /// files.</param>
        public SharedFileMetadata(FolderPolicy policy,
                                  string previewUrl,
                                  string name,
                                  string id,
                                  col.IEnumerable<FilePermission> permissions = null,
                                  Dropbox.Api.Users.Team ownerTeam = null,
                                  string parentSharedFolderId = null,
                                  string pathLower = null,
                                  string pathDisplay = null)
        {
            if (policy == null)
            {
                throw new sys.ArgumentNullException("policy");
            }

            if (previewUrl == null)
            {
                throw new sys.ArgumentNullException("previewUrl");
            }

            if (name == null)
            {
                throw new sys.ArgumentNullException("name");
            }

            if (id == null)
            {
                throw new sys.ArgumentNullException("id");
            }
            if (id.Length < 1)
            {
                throw new sys.ArgumentOutOfRangeException("id", "Length should be at least 1");
            }
            if (!re.Regex.IsMatch(id, @"\A(?:id:.*)\z"))
            {
                throw new sys.ArgumentOutOfRangeException("id", @"Value should match pattern '\A(?:id:.*)\z'");
            }

            var permissionsList = enc.Util.ToList(permissions);

            if (parentSharedFolderId != null)
            {
                if (!re.Regex.IsMatch(parentSharedFolderId, @"\A(?:[-_0-9a-zA-Z:]+)\z"))
                {
                    throw new sys.ArgumentOutOfRangeException("parentSharedFolderId", @"Value should match pattern '\A(?:[-_0-9a-zA-Z:]+)\z'");
                }
            }

            this.Policy = policy;
            this.PreviewUrl = previewUrl;
            this.Name = name;
            this.Id = id;
            this.Permissions = permissionsList;
            this.OwnerTeam = ownerTeam;
            this.ParentSharedFolderId = parentSharedFolderId;
            this.PathLower = pathLower;
            this.PathDisplay = pathDisplay;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="SharedFileMetadata" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public SharedFileMetadata()
        {
        }

        /// <summary>
        /// <para>Policies governing this shared file.</para>
        /// </summary>
        public FolderPolicy Policy { get; protected set; }

        /// <summary>
        /// <para>URL for displaying a web preview of the shared file.</para>
        /// </summary>
        public string PreviewUrl { get; protected set; }

        /// <summary>
        /// <para>The name of this file.</para>
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// <para>The ID of the file.</para>
        /// </summary>
        public string Id { get; protected set; }

        /// <summary>
        /// <para>The sharing permissions that requesting user has on this file. This
        /// corresponds to the entries given in <see
        /// cref="Dropbox.Api.Sharing.GetFileMetadataBatchArg.Actions" /> or <see
        /// cref="Dropbox.Api.Sharing.GetFileMetadataArg.Actions" />.</para>
        /// </summary>
        public col.IList<FilePermission> Permissions { get; protected set; }

        /// <summary>
        /// <para>The team that owns the file. This field is not present if the file is not
        /// owned by a team.</para>
        /// </summary>
        public Dropbox.Api.Users.Team OwnerTeam { get; protected set; }

        /// <summary>
        /// <para>The ID of the parent shared folder. This field is present only if the file is
        /// contained within a shared folder.</para>
        /// </summary>
        public string ParentSharedFolderId { get; protected set; }

        /// <summary>
        /// <para>The lower-case full path of this file. Absent for unmounted files.</para>
        /// </summary>
        public string PathLower { get; protected set; }

        /// <summary>
        /// <para>The cased path to be used for display purposes only. In rare instances the
        /// casing will not correctly match the user's filesystem, but this behavior will match
        /// the path provided in the Core API v1. Absent for unmounted files.</para>
        /// </summary>
        public string PathDisplay { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="SharedFileMetadata" />.</para>
        /// </summary>
        private class SharedFileMetadataEncoder : enc.StructEncoder<SharedFileMetadata>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(SharedFileMetadata value, enc.IJsonWriter writer)
            {
                WriteProperty("policy", value.Policy, writer, Dropbox.Api.Sharing.FolderPolicy.Encoder);
                WriteProperty("preview_url", value.PreviewUrl, writer, enc.StringEncoder.Instance);
                WriteProperty("name", value.Name, writer, enc.StringEncoder.Instance);
                WriteProperty("id", value.Id, writer, enc.StringEncoder.Instance);
                if (value.Permissions.Count > 0)
                {
                    WriteListProperty("permissions", value.Permissions, writer, Dropbox.Api.Sharing.FilePermission.Encoder);
                }
                if (value.OwnerTeam != null)
                {
                    WriteProperty("owner_team", value.OwnerTeam, writer, Dropbox.Api.Users.Team.Encoder);
                }
                if (value.ParentSharedFolderId != null)
                {
                    WriteProperty("parent_shared_folder_id", value.ParentSharedFolderId, writer, enc.StringEncoder.Instance);
                }
                if (value.PathLower != null)
                {
                    WriteProperty("path_lower", value.PathLower, writer, enc.StringEncoder.Instance);
                }
                if (value.PathDisplay != null)
                {
                    WriteProperty("path_display", value.PathDisplay, writer, enc.StringEncoder.Instance);
                }
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="SharedFileMetadata" />.</para>
        /// </summary>
        private class SharedFileMetadataDecoder : enc.StructDecoder<SharedFileMetadata>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="SharedFileMetadata" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override SharedFileMetadata Create()
            {
                return new SharedFileMetadata();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(SharedFileMetadata value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "policy":
                        value.Policy = Dropbox.Api.Sharing.FolderPolicy.Decoder.Decode(reader);
                        break;
                    case "preview_url":
                        value.PreviewUrl = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "name":
                        value.Name = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "id":
                        value.Id = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "permissions":
                        value.Permissions = ReadList<FilePermission>(reader, Dropbox.Api.Sharing.FilePermission.Decoder);
                        break;
                    case "owner_team":
                        value.OwnerTeam = Dropbox.Api.Users.Team.Decoder.Decode(reader);
                        break;
                    case "parent_shared_folder_id":
                        value.ParentSharedFolderId = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "path_lower":
                        value.PathLower = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "path_display":
                        value.PathDisplay = enc.StringDecoder.Instance.Decode(reader);
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
