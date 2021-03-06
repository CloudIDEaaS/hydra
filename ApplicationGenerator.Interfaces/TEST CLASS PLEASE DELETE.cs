﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace contoso.Entities
{
    using System;
    using System.Collections.Generic;
    using AbstraX.DataAnnotations;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;


    [MetadataTypeAttribute(typeof(UserMetadata))]
    public partial class User
    {
    }

    [IdentityEntityAttribute(IdentityEntityKind.User)]
    [UINavigationNameAttribute("Login")]
    [UIAttribute("Login", UIKind.LoginPage, false)]
    [AuthorizeAttribute(AuthorizationState.SkipAuthorization)]
    public partial class UserMetadata
    {

        [IdentityFieldAttribute("*", IdentityFieldKind.Client)]
        [DisplayNameAttribute("First Name")]
        public string FirstName { get; set; }

        [IdentityFieldAttribute("*", IdentityFieldKind.Client)]
        [DisplayNameAttribute("Last Name")]
        public string LastName { get; set; }

        [IdentityFieldAttribute("*", IdentityFieldKind.UserName)]
        [DisplayNameAttribute("User Name")]
        [MinLengthAttribute(8)]
        [MaxLengthAttribute(50)]
        public string UserName { get; set; }

        [DataTypeAttribute(DataType.EmailAddress)]
        [IdentityFieldAttribute("*", IdentityFieldKind.Client)]
        [DisplayNameAttribute("Email Address")]
        public string EmailAddress { get; set; }

        [IdentityFieldAttribute("*", IdentityFieldKind.PasswordHash)]
        [DisplayNameAttribute("Password")]
        [MinLengthAttribute(8)]
        [MaxLengthAttribute(50)]
        public string PasswordHash { get; set; }

        public bool Enabled { get; set; }
    }
}
