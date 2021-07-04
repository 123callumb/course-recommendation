import { ArrowRightIcon } from "@chakra-ui/icons";
import { Box, Button, Container, Divider, Heading, Progress, Text } from "@chakra-ui/react";
import React from "react";
import Course from "../Models/Course";
import CourseRecommendationRequest from "../Models/Requests/CourseRecommendationRequest";
import CourseRecommendationResponse from "../Models/Responses/CourseRecommendationResponse";
import RequestManager, { RequestURL } from "../Services/RequestManager";

interface RecommendationPage_State {
    RecommendedCourse?: Course;
}

export default class RecommendationPage_Comp extends React.Component<any, RecommendationPage_State> {
    constructor(props: any) {
        super(props);

        this.state = {
            RecommendedCourse: null
        };

        this.GenerateRecommendation();
    }

    async GenerateRecommendation() {
        const currentSessionID = sessionStorage['recommendation_session'] ?? "0";
        const res = await RequestManager.MakeRequest<CourseRecommendationResponse, CourseRecommendationRequest>(RequestURL.Recommendation_Get, "POST", {
            SessionID: parseInt(currentSessionID)
        });

        if (res.success) {
            sessionStorage['recommendation_session'] = res.data.SessionID;
            this.setState({
                RecommendedCourse: res.data.RecommendedCourse
            });
        }
    }

    render() {
        return <Container maxW="container.md" pt="4">
            <Box boxShadow="md" p="2">
                <Heading size="md">Course Recommendation</Heading>
                <Divider my="2" />
                {this.state.RecommendedCourse === null ?
                    <>
                        <Text fontSize="sm">Generating recommendations based on your answers...</Text>
                        <Progress isIndeterminate={true} size="xs" />
                    </>
                    :
                    <>
                        <Text fontSize="md">Base on your answers, to improve your digital skills further you should consider taking the following course:</Text>
                        <Container maxW="container.sm" my="6">
                            <Box borderWidth="1px" borderRadius="lg" p="4">
                                <Heading size="sm" mb="2">{this.state.RecommendedCourse.Name}</Heading>
                                <Text>{this.state.RecommendedCourse.Description}</Text>
                                <Box textAlign="center" mt="4">
                                    <Button colorScheme="teal" href="#" leftIcon={<ArrowRightIcon />}>
                                        Sign up to Course
                                    </Button>
                                </Box>
                            </Box>
                        </Container>
                    </>}
            </Box>
        </Container>;
    }
}