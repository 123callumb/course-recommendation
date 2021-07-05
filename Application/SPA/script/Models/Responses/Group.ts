import Section from "../Section";

export default interface Group {
    GroupID: number;
    Name: string;
    Description: string;
    Sections: Section[];
}