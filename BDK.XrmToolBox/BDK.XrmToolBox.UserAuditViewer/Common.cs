/*
MIT License

Copyright (c) 2019 Tech Quantum

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */


namespace BDK.XrmToolBox.UserAuditViewer
{
    /// <summary>
    /// Audit action enum
    /// </summary>
    public enum AuditAction
    {

        /// <summary>
        /// The unknown
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unknown = 0,

        /// <summary>
        /// The create
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Create = 1,

        /// <summary>
        /// The update
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Update = 2,

        /// <summary>
        /// The delete
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Delete = 3,

        /// <summary>
        /// The activate
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Activate = 4,

        /// <summary>
        /// The deactivate
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deactivate = 5,

        /// <summary>
        /// The cascade
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cascade = 11,

        /// <summary>
        /// The merge
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Merge = 12,

        /// <summary>
        /// The assign
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Assign = 13,

        /// <summary>
        /// The share
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Share = 14,

        /// <summary>
        /// The retrieve
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Retrieve = 15,

        /// <summary>
        /// The close
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Close = 16,

        /// <summary>
        /// The cancel
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cancel = 17,

        /// <summary>
        /// The complete
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Complete = 18,

        /// <summary>
        /// The resolve
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Resolve = 20,

        /// <summary>
        /// The reopen
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Reopen = 21,

        /// <summary>
        /// The fulfill
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Fulfill = 22,

        /// <summary>
        /// The paid
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Paid = 23,

        /// <summary>
        /// The qualify
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Qualify = 24,

        /// <summary>
        /// The disqualify
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Disqualify = 25,

        /// <summary>
        /// The submit
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Submit = 26,

        /// <summary>
        /// The reject
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Reject = 27,

        /// <summary>
        /// The approve
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Approve = 28,

        /// <summary>
        /// The invoice
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Invoice = 29,

        /// <summary>
        /// The hold
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Hold = 30,

        /// <summary>
        /// The add member
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddMember = 31,

        /// <summary>
        /// The remove member
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveMember = 32,

        /// <summary>
        /// The associate entities
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AssociateEntities = 33,

        /// <summary>
        /// The disassociate entities
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DisassociateEntities = 34,

        /// <summary>
        /// The add members
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddMembers = 35,

        /// <summary>
        /// The remove members
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveMembers = 36,

        /// <summary>
        /// The add item
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddItem = 37,

        /// <summary>
        /// The remove item
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveItem = 38,

        /// <summary>
        /// The add substitute
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddSubstitute = 39,

        /// <summary>
        /// The remove substitute
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveSubstitute = 40,

        /// <summary>
        /// The set state
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SetState = 41,

        /// <summary>
        /// The renew
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Renew = 42,

        /// <summary>
        /// The revise
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Revise = 43,

        /// <summary>
        /// The win
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Win = 44,

        /// <summary>
        /// The lose
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Lose = 45,

        /// <summary>
        /// The internal processing
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InternalProcessing = 46,

        /// <summary>
        /// The reschedule
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Reschedule = 47,

        /// <summary>
        /// The modify share
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ModifyShare = 48,

        /// <summary>
        /// The unshare
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unshare = 49,

        /// <summary>
        /// The book
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Book = 50,

        /// <summary>
        /// The generate quote from opportunity
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GenerateQuoteFromOpportunity = 51,

        /// <summary>
        /// The add to queue
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddToQueue = 52,

        /// <summary>
        /// The assign role to team
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AssignRoleToTeam = 53,

        /// <summary>
        /// The remove role from team
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveRoleFromTeam = 54,

        /// <summary>
        /// The assign role to user
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AssignRoleToUser = 55,

        /// <summary>
        /// The remove role from user
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemoveRoleFromUser = 56,

        /// <summary>
        /// The add privilegesto role
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddPrivilegestoRole = 57,

        /// <summary>
        /// The remove privileges from role
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RemovePrivilegesFromRole = 58,

        /// <summary>
        /// The replace privileges in role
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ReplacePrivilegesInRole = 59,

        /// <summary>
        /// The import mappings
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ImportMappings = 60,

        /// <summary>
        /// The clone
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Clone = 61,

        /// <summary>
        /// The send direct email
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        SendDirectEmail = 62,

        /// <summary>
        /// The enabledfororganization
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Enabledfororganization = 63,

        /// <summary>
        /// The user accessvia web
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserAccessviaWeb = 64,

        /// <summary>
        /// The user accessvia web services
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserAccessviaWebServices = 65,

        /// <summary>
        /// The delete entity
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DeleteEntity = 100,

        /// <summary>
        /// The delete attribute
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DeleteAttribute = 101,

        /// <summary>
        /// The audit changeat entity level
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditChangeatEntityLevel = 102,

        /// <summary>
        /// The audit changeat attribute level
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditChangeatAttributeLevel = 103,

        /// <summary>
        /// The audit changeat org level
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditChangeatOrgLevel = 104,

        /// <summary>
        /// The entity audit started
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EntityAuditStarted = 105,

        /// <summary>
        /// The attribute audit started
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AttributeAuditStarted = 106,

        /// <summary>
        /// The audit enabled
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditEnabled = 107,

        /// <summary>
        /// The entity audit stopped
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EntityAuditStopped = 108,

        /// <summary>
        /// The attribute audit stopped
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AttributeAuditStopped = 109,

        /// <summary>
        /// The audit disabled
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditDisabled = 110,

        /// <summary>
        /// The audit log deletion
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AuditLogDeletion = 111,

        /// <summary>
        /// The user access audit started
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserAccessAuditStarted = 112,

        /// <summary>
        /// The user access audit stopped
        /// </summary>
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserAccessAuditStopped = 113,
    }

    /// <summary>
    /// Audit operation enum
    /// </summary>
    public enum AuditOperation
    {
        /// <summary>
        /// The create
        /// </summary>
        Create = 1,

        /// <summary>
        /// The update
        /// </summary>
        Update = 2,

        /// <summary>
        /// The delete
        /// </summary>
        Delete = 3,

        /// <summary>
        /// The access
        /// </summary>
        Access = 4,
    }
}
