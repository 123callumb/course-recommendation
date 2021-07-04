import { Box, Container, Divider, Progress, Text } from "@chakra-ui/react";
import React from "react";

export default class RecommendationPage_Comp extends React.Component {
    constructor(props: any) {
        super(props);
    }

    GenerateRecommendation() {

    }

    render() {
        return <Container maxW="container.md" pt="4">
            <Box boxShadow="md" p="2">
                <Text fontSize="lg">Course Recommendation</Text>
                <Divider my="2" />
                {true ?
                    <>
                        <Text fontSize="sm">Generating recommendations based on your answers...</Text>
                        <Progress isIndeterminate={true} size="xs" />
                    </>
                    :
                    <Text fontSize="md">Base on your answers, to improve your digital skills further you should consider taking the following course:</Text>}
            </Box>
        </Container>;
    }
}