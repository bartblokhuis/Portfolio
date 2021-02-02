import { BaseEntity } from './BaseEntity';

export enum MessageStatus {
    Unread,
    Read,
    WaitingResponse,
    Closed
  }
  
export interface Message extends BaseEntity {
    firstName: string,
    lastName: string,
    emailAddress: string,
    message: string,
    receivedDate: string,
    lastUpdatedDate?: string,
    status: MessageStatus
}

export const MessageStatusToLabelMapping = {
    [MessageStatus.Unread]: "Unread",
    [MessageStatus.Read]: "Read",
    [MessageStatus.WaitingResponse]: "Awaiting response",
    [MessageStatus.Closed]: "Closed",
  }